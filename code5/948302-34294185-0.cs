    using UnityEngine;
    using System.Collections;
    
    public class chicken_for : MonoBehaviour {
    
    //This function will handle the collision on your object
    void OnCollisionEnter (Collider col){
        if(col.gameobject.tag == "Player"){    //if colliding object if tagged player
            Application.LoadLevel("SciFi Level"); //load the sci-fi level
        }
    }
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
            
        }
    }
