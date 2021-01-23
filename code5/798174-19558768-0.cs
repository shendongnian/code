    using UnityEngine;
    using System.Collections;
    public class Example : MonoBehaviour {
	    void OnGUI() {
		    Vector2 screenPos = Event.current.mousePosition;
		    GUI.Button ( new Rect(screenPos.x,screenPos.y,100,100),"Hello");
	}
    }
