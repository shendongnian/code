    if(Input.GetKeyDown("f")) 
		{
			FirstCamera.GetComponent<Camera>().enabled = false;
			SecondCamera.GetComponent<Camera>().enabled = true;
		}
		
		if(Input.GetKeyDown("r"))
		{
			FirstCamera.GetComponent<Camera>().enabled = true;
			SecondCamera.GetComponent<Camera>().enabled = false;   
		}
