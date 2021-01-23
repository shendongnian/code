    using UnityEngine;
    using System.Collections;
    public class TurretScript : MonoBehaviour {
	    //This variable controls the rate of ball spawn
	    public float ballFireTime = 1;
	    //Counter for time.
	    public float thisBallFireTime = 1;
	
	    // Use this for initialization
	    void Start () {
		    thisBallFireTime = ballFireTime;
	    }
	
	    // Update is called once per frame
	    void Update () {
            
            //Reduce the time 
		    thisBallFireTime -= Time.deltaTime;
            //If the time reaches 0, we need to spawn a new ball
		    if(thisBallFireTime <= 0) {
                //Reset the ball spawn time
			    thisBallFireTime = ballFireTime;
                //Instantiate a new ball
			    GameObject thisBall = Instantiate(TurretExampleManager.instance.ballPrefab, transform.position, Quaternion.identity) as GameObject;
                //Add the Ball Script to the newly spawned ball
			    thisBall.AddComponent<BallScript>();
		    }
	    }
    }
