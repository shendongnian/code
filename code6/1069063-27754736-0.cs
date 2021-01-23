    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class DetectVGesture : MonoBehaviour {
	//Note : This was tested on a 1st Gen Moto G (1280 x 720 resolution, IIRC)
	// and an orthographic size of 5.
	//Why this matters :
	//The Vector2 minimumDeltas uses Screen units, so resolution matters here
	//The float maxDistBetInitPos uses World units, so if the camera's ortho size is larger, this value becomes larger as well
	//Therefore, some trial and error in these values will be needed to get it to work right
	//TODO : Write some code to take into account screen resolution and camera size / FOV.
	//If anyone feels like editing that portion in, please feel free
	//The touches used are maintained in these two lists
	private List<Touch> firstTouches = new List<Touch>();
	private List<Touch> secondTouches = new List<Touch>();
	//This is the minimum distance in SCREEN units 
	//of touch.deltaTouch for a new touch in TouchPhase.Moved to register
	public Vector2 minimumDeltas = new Vector2(1, 1);
	
	//This is the maximum distance between the two initial touches
	//in WORLD units for the algorithm to work
	public float maxDistBetInitPos = 3f;
	//These are the minimum and maximum angles between the two
	//"ARMS" of the "V" for a V gesture to be recognized
	public Vector2 vAnglesMinMax = new Vector2(15, 60);
	// Use this for initialization
	void Start () {
	}
	void OnGUI () {
		GUI.Label(new Rect(10, 10, 100, 50), "Touches "+Input.touchCount.ToString());
		if(Input.touchCount > 0)
			GUI.Label(new Rect(110, 10, 100, 50), "Touch1 "+Input.touches[0].position.ToString());
		if(Input.touchCount > 1)
			GUI.Label(new Rect(210, 10, 100, 50), "Touch2 "+Input.touches[1].position.ToString());
	}
	// Update is called once per frame
	void Update () {
	
		//For this sample, we're only interested in a "V" created with 
		//2 fingers, so we'l ignore the rest
		if(Input.touchCount == 2) {
			foreach(Touch touch in Input.touches) {
				//The below two lines are to allow for an early
				//exit if EITHER of the fingers is stationary. 
				//Uncomment the lines if you want touches to be registered
				//only when BOTH fingers move.
				//if(touch.phase == TouchPhase.Stationary)
					//return;
				//This is the first time TWO fingers are registered,
				//so we can use this as our starting point, where the
				//touches are closest to each other. 
				//From here on, I'll refer this to as the BOTTOM of the "V"
				if(touch.phase == TouchPhase.Began) {
					CheckTouchAndAdd(Input.touches[0], Input.touches[1]);
				}
				//There was some movement, so let's check what it is
				if(touch.phase == TouchPhase.Moved) {
					//The movement in this touch is at least as much as we want
					//So, we add both the touches, and we move to the next iteration
					//Here, I want both the X & Y delta positions to meet my minimum
					//delta distance. You can change this to either X or Y.
					if(Mathf.Abs(touch.deltaPosition.x) >= minimumDeltas.x &&
					   Mathf.Abs(touch.deltaPosition.y) >= minimumDeltas.y) {
						CheckTouchAndAdd(Input.touches[0], Input.touches[1]);
					}
					else {
						Debug.Log("There was too less of delta!");
					}
				}
				//The touch / touches have ended. 
				//So let's clear the lists for the next trial
				if(touch.phase == TouchPhase.Ended) {
					firstTouches.Clear();
					secondTouches.Clear();
				}
			}//Iterate over touches in Input.touches ends
		}//Input.touchCount == 2 ends
	}
	private void CheckTouchAndAdd (Touch touch1, Touch touch2) {
		if(!firstTouches.Contains(touch1) && !secondTouches.Contains(touch2)) {
			firstTouches.Add(touch1);
			secondTouches.Add(touch2);
			CheckForV();
		}
	}
	
	private void CheckForV () {
		if(firstTouches.Count < 5 || secondTouches.Count < 5) {
			Debug.Log("Not enough touches to perform the check! ");
			return;
		}
		//First, let's check if the two initial touch points
		//were relatively close enough to warrant a "V"
		//If they're not, we'll have an early exit
		Vector3 firstTouchInitPos = Camera.main.ScreenToWorldPoint(firstTouches[0].position);
		Vector3 secondTouchInitPos = Camera.main.ScreenToWorldPoint(secondTouches[0].position);
		//First we check if the X distance falls within our limit of maximum distance
		if(Mathf.Abs(secondTouchInitPos.x - firstTouchInitPos.x) > maxDistBetInitPos) {
			Debug.Log (string.Format("The X values were too far apart! Exiting check First {0}," +
			                         "Second {1}, Distance {2}", 
			                         new object[] { firstTouchInitPos.x, secondTouchInitPos.x, 
			Mathf.Abs(secondTouchInitPos.x - firstTouchInitPos.x)} ));
			return;
		}
		//Then we check the same for Y
		if(Mathf.Abs(secondTouchInitPos.y - firstTouchInitPos.y) > maxDistBetInitPos) {
			Debug.Log (string.Format("The Y values were too far apart! Exiting check First {0}," +
			                         "Second {1}, Distance {2}", 
			                         new object[] { firstTouchInitPos.y, secondTouchInitPos.y, 
				Mathf.Abs(secondTouchInitPos.y - firstTouchInitPos.y)} ));
			return;
		}
		//If we reach this point, both the X & the Y positions are within the maximum distance
		//we want. So, they're close enough that we can calculate the average between the two Vectors
		//and assume that both these Vectors intersect at the average point. (i.e. the average point
		//is the corner at the BOTTOM of the "V")
		//Note that there are more elegant ways of doing this. You can always use trignometry to do so
		//but for the sake of this example, this should yield fairly good results.
		Vector3 bottomCornerPoint = new Vector3( (firstTouchInitPos.x + secondTouchInitPos.x) * 0.5f, 
		                                        (firstTouchInitPos.y + secondTouchInitPos.y) * 0.5f );
		//Now that we have our bottom point, we then calculate the Vector between this common
		//bottom point, and the last touch point added to each list. From this point
		//I'll refer to these two Vectors as the ARMS of the "V" 
		Vector3 arm1 = new Vector3( firstTouches[firstTouches.Count - 1].position.x - bottomCornerPoint.x,
		                           firstTouches[firstTouches.Count - 1].position.y - bottomCornerPoint.y );
		Vector3 arm2 = new Vector3( secondTouches[secondTouches.Count - 1].position.x - bottomCornerPoint.x,
		                           secondTouches[secondTouches.Count - 1].position.y - bottomCornerPoint.y );
		//Now let's calculate the angle between the ARMS of the "V".
		//If the angle is too small (< 15 degrees), or too large (> 60 degrees), 
		//it's not really a "V", so we'll exit
		//Note: Vector2.Angle / Vector3.Angle perform a DOT product of the two vectors
		//Therefore in certain cases, you're going to get incorrect results.
		//TODO : If anyone can, please change the below to use a cross product
		//to calculate the angle between the Vectors.
		if(Vector3.Angle(arm1, arm2) < vAnglesMinMax.x ||
		   Vector3.Angle(arm1, arm2) > vAnglesMinMax.y) {
			Debug.Log (string.Format("The angle was outside the allowed range! Angle {0}", 
			                         new object[] { Vector3.Angle(arm1, arm2) } ));
			return;
		}
		//If we reach this point, everything's great, we have a "V"!
		Debug.Log ("There's a V gesture here!");
	}
    }
