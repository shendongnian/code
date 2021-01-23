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
		    thisBallFireTime -= Time.deltaTime;
		    if(thisBallFireTime <= 0) {
			    thisBallFireTime = ballFireTime;
			    GameObject thisBall = Instantiate(TurretExampleManager.instance.ballPrefab, transform.position, Quaternion.identity) as GameObject;
			    thisBall.AddComponent<BallScript>();
		    }
	    }
    }
