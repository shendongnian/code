    void Update () {
    	// Handle native touch events
	    foreach (Touch touch in Input.touches) {
    		HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);
    	}
 
    	// Simulate touch events from mouse events
    	if (Input.touchCount == 0) {
    		if (Input.GetMouseButtonDown(0) ) {
    			HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Began);
    		}
    		if (Input.GetMouseButton(0) ) {
    			HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Moved);
		    }
    		if (Input.GetMouseButtonUp(0) ) {
    			HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Ended);
    		}
    	}
    }
 
    private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase) {
    	switch (touchPhase) {
    	case TouchPhase.Began:
    		// TODO
    		break;
    	case TouchPhase.Moved:
    		// TODO
    		break;
    	case TouchPhase.Ended:
    		// TODO
    		break;
    	}
    }
