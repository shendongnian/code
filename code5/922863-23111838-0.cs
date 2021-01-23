    using UnityEngine;
    using System.Collections;
    public class Rotator : MonoBehaviour 
    {
    	private float currentRotation = 20.0f;
    	
        void OnGUI() 
    	{
            currentRotation = GUI.HorizontalSlider(new Rect(35, 75, 200, 30), currentRotation , 0.0f,  50.0f);
            transform.localEulerAngles = new Vector3(0.0f, currentRotation, 0.0f);
        }
    	
    }
