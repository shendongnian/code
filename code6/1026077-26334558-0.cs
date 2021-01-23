    using UnityEngine;
    using System.Collections;
    
    public class VROneHeadLook : MonoBehaviour {
    	public bool useAngleX = true;	
    	public bool useAngleY = true;
    	public bool useAngleZ = true;
    	public bool useRealHorizontalAngle = false;
    	public bool resetViewOnTouch = true;
    	
    	private Quaternion initialRotation = Quaternion.identity;
    	private Quaternion currentRotation;
    	private static Vector3 gyroAngles; // original angles from gyro
    	private static Vector3 usedAngles; // converted into unity world coordinates
    	
    	private int userSleepTimeOut; // original device SleepTimeOut setting
    	private bool gyroAvail = false;
    
    	// Use this for initialization
    	void Start () {
    		Input.compensateSensors = true;
    	}
    	
    	// Update is called once per frame
    	void FixedUpdate () {
    		if (gyroAvail == false) {
    			if (Input.gyro.attitude.eulerAngles != Vector3.zero && Time.frameCount > 30) {
    				gyroAvail = true;
    				initialRotation = Input.gyro.attitude;
    			}
    			return; // early out
    		}
    		
    		// reset origin on touch or not yet set origin
    		if(resetViewOnTouch && (Input.touchCount > 0))
    			initialRotation = Input.gyro.attitude;
    		
    		// new rotation
    		currentRotation = Quaternion.Inverse(initialRotation)*Input.gyro.attitude;
    		
    		gyroAngles = currentRotation.eulerAngles;
    		
    		//usedAngles = Quaternion.Inverse (currentRotation).eulerAngles;
    		usedAngles = gyroAngles;
    		
    		// reset single angle values
    		if (useAngleX == false)
    			usedAngles.x = 0f;
    		if (useAngleY == false)
    			usedAngles.y = 0f;
    		if (useAngleZ == false)
    			usedAngles.z = 0f;
    		
    		if (useRealHorizontalAngle)
    			usedAngles.y *= -1;
    		transform.localRotation = Quaternion.Euler (new Vector3(-usedAngles.x, usedAngles.y, usedAngles.z));
    	}
    	void OnEnable() {
    		// sensor on
    		Input.gyro.enabled = true;
    		initialRotation = Quaternion.identity;
    		gyroAvail = false;
    		
    		// store device sleep timeout setting
    		userSleepTimeOut = Screen.sleepTimeout;
    		// disable sleep timeout when app is running
    		Screen.sleepTimeout = SleepTimeout.NeverSleep;
    	}
    	
    	void OnDisable() {
    		// restore original sleep timeout
    		Screen.sleepTimeout = userSleepTimeOut;
    		//sensor off
    		Input.gyro.enabled = false;
    	}
    }
