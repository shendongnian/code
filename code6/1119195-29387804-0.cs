    void Update()
    {
    	if (Input.GetMouseButtonDown(1))
    	{
    		var ray = camera.ScreenPointToRay(Input.mousePosition);
    		RaycastHit hitInfo;
    		if (Physics.Raycast(ray, out hitInfo))
    		{
    			var myObject = hitInfo.collider.GetComponent<MyScriptOrSomething>();
    			// Do something here
    		}
    	}
    }
