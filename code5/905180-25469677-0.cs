    using UnityEngine;
    using System.Collections;
    
    enum AxisDirection {
    	x, y
    }
    
    [RequireComponent (typeof (SliderJoint2D))]
    public class AxisLock : MonoBehaviour {
    	[SerializeField] AxisDirection lockAxis;
    
    	void Awake () {
    		SliderJoint2D slider = GetComponent<SliderJoint2D>();
    
    		slider.connectedAnchor = new Vector2(transform.position.x, transform.position.y);
    		slider.collideConnected = true;
    
    		if (lockAxis == AxisDirection.x) {
    			slider.angle = 90;
    		} else {
    			slider.angle = 0;
    		}
    	}
    }
