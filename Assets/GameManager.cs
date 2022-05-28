using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    int score = 0;
    int turnCounter = 0;
    GameObject[] pins;
    public Text scoreUI;
    public GameObject menu;

    //Vector3[] positions;

    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        //positions = new Vector3[pins.Length];

        //for(int i = 0; i<pins.Length; i++) 
        //{
        //    positions[i] = pins[i].transform.position;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();

        if(Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -13)
        {
            CountPinsDown();
            //turnCounter++;
            //ResetPins();
        }
    }

    void MoveBall()
    {
        Vector3 position = ball.transform.position;
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -5000f, 5000f);
        ball.transform.position = position;

    }

    void CountPinsDown()
    {
        for(int i=0; i < pins.Length; i++)
        {
            if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 )
            //&& pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }

        }
        
        Debug.Log(score);
        scoreUI.text = score.ToString();
        menu.SetActive(true);
    }

    // void ResetPins()
    // {
    //   for(int i=0; i < pins.Length;i++)
    //   {
    //        pins[i].SetActive(true);
    //        pins[i].transform.position=positions[i];
    //        pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
    //        pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //        pins[i].transform.rotation = Quaternion.identity;
    //    }

    //    ball.transform.position= new Vector3(-2.2f, -6.2f, -82.96f);
    //    ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //    ball.transform.rotation = Quaternion.identity;
    //}
}