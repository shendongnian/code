    using UnityEngine;
    using System.Collections.Generic;
    
    public class VirtualButtonEvent : MonoBehaviour, IVirtualButtonEventHandler {
    	
    	public GameObject Sphere;
    	public float speed;
    	
    	// register buttons for event handling
    	void Start() {
    		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
    		for (int i = 0; i < vbs.Length; ++i) { vbs[i].RegisterEventHandler(this); }
    	}
    	
    	// button is "pressed" to move Sphere
    	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
    		if (vb.VirtualButtonName=="Up")  { 
    			Sphere.rigidbody.AddForce(new Vector3 (0, 0, speed) * speed);
    		}
    		if (vb.VirtualButtonName=="Down") {  
    			Sphere.rigidbody.AddForce(new Vector3 (0, 0, -speed) * speed);
    		}
    		if (vb.VirtualButtonName=="Left") { 
    			Sphere.rigidbody.AddForce(new Vector3 (-speed, 0, 0) * speed);
    		}
    		if (vb.VirtualButtonName=="Right") { 
    			Sphere.rigidbody.AddForce(new Vector3 (speed, 0, 0) * speed);
    		}
    	}
    
    	// Release to stop Sphere? (Maybe. Don't think this will stop the ball from moving.
    	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
    		if (vb.VirtualButtonName=="Up")  {  
    			Sphere.rigidbody.AddForce(new Vector3 (0, 0, 0));
    		}
    		if (vb.VirtualButtonName=="Down") {  
    			Sphere.rigidbody.AddForce(new Vector3 (0, 0, 0));
    		}
    		if (vb.VirtualButtonName=="Left") {  
    			Sphere.rigidbody.AddForce(new Vector3 (0, 0, 0));
    		}
    		if (vb.VirtualButtonName=="Right") {  
    			Sphere.rigidbody.AddForce(new Vector3 (0, 0, 0));
    		}
    	}
    	
    }
