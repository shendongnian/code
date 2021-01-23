    using UnityEngine;
    using System.Collections;
    public class Mover : MonoBehaviour {
		public void MoveButtonPressed()
		{
			lastPressedTime = Time.timeSinceLevelLoad;
		}
		
		public double moveTime = 0.1;
	    private double lastPressedTime = 0.0;
		void Update()
	    {
		    if(lastPressedTime + moveTime > Time.timeSinceLevelLoad)
			{
                // Character is moving
				rigidbody.velocity = new Vector3(1.0f, 0.0f, 0.0f);
			}
			else
			{
				rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
			}
		}
    }
