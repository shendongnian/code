    var speed = 0.1;
    function Update () {
    	if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
    	
    		// Get movement of the finger since last frame
    		var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
    		
    		// Move object across XY plane
    		var rotationVector = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 0);
    		transform.Rotate(rotationVector * speed, Space.World);
    	}
    }
