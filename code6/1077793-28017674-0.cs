    using UnityEngine;
    using System.Collections;
    public class TouchMove : MonoBehaviour {
	    //This is the player Transform. Assign it in the inspector
	    public Transform player;
	    //This is where we'll store the touched positon;
	    public Vector3 touchPoint = Vector3.zero;
	    // Update is called once per frame
	    void Update () {
	
		    // Mouse input is registered even on mobile devices. 
		    // You can always change this to use the Input.Touch class,
		    // but since mouse input works on both mobile, as well as the editor
		    // I use Input.GetMouse instead.
		    if(Input.GetMouseButtonDown(0)) {
			    //We take the point where the touch occured and convert the units
			    //of this touch from screen space to world space
			    //Unity's API doc for ScreenToWorldPoint
			    //http://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
			    touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			    Debug.Log (touchPoint);
			    //I assume that the camera is looking "down" on the player.
			    //Therefor the player moves only on the X & Z axis. We want to keep the player's
			    //Y co-ordinate the same so that it doesn't move further away or closer to the camera
			    //If your camera is oriented differently (i.e. other than in the Y axis, looking down)
			    //change the below line.
			    touchPoint.y = player.position.y;
	    	}
		    //The player is not at the touched position, so we need to rotate
		    //the player to look at the final touch position, and move the player toward that position
		    if(!Mathf.Approximately(player.position.x, touchPoint.x) ||
		       !Mathf.Approximately(player.position.z, touchPoint.z) ) {
			    player.LookAt(touchPoint);
			    player.Translate(Vector3.forward * Time.deltaTime);
		    }
	    }
    }
