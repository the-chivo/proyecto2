using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text referenceNumberText;
    [SerializeField] TMP_Text playerNumberText;
    [SerializeField] float numberCountSpeed = 1;
    [SerializeField] TMP_Text pressSpaceMesagge;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text recordText;
    int record = 0;
    int score = -1;
    bool spaceIsPressed = false;
    int referenceNumber = 0;
    int playerNumber = 0;
    float clock = 0;
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {   
        //la cuenta hacia delante del numero
            clock = Time.deltaTime + clock;
        if (clock >= numberCountSpeed && spaceIsPressed == true)
        {
            playerNumber += 1;
            playerNumberText.text = playerNumber.ToString();
            clock = 0;
        }
        
       
        if(Input.GetKeyDown(KeyCode.Space) && playerNumber == referenceNumber)
        {   
            score = score + 1;
            scoreText.text = score.ToString();
            playerNumber = 0;
            playerNumberText.text = playerNumber.ToString();
            referenceNumber = Random.Range(2,10);
            referenceNumberText.text = referenceNumber.ToString();
            pressSpaceMesagge.enabled = false;
            spaceIsPressed = true;
            numberCountSpeed = numberCountSpeed * 0.9f; 
        }
        else if(Input.GetKeyDown(KeyCode.Space) && playerNumber > referenceNumber || Input.GetKeyDown(KeyCode.Space) && playerNumber < referenceNumber)
        {  
            if (score > record)
            {
                record = score;
                recordText.text = record.ToString();
                print(record);
            }          
            score = 0;
            scoreText.text = score.ToString();
            playerNumber = 0;
            playerNumberText.text = playerNumber.ToString();
            referenceNumber = Random.Range(2,10);
            referenceNumberText.text = referenceNumber.ToString();
            numberCountSpeed = 1;
               
        }
        
        
    }   
    

    
}
