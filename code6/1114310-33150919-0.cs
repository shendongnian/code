    void Update ()
    {
        timer += Time.deltaTime; 
        
        if (Input.touchCount > 0)
    	{    			
    		if (Input.GetTouch(0).phase == TouchPhase.Began)
    	    {
    			Shoot ();
    		}
    	}
    }
