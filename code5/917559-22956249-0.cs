	void FixedUpdate () 
	{
	
		if (!Options.useController)
		{
	        	Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
	    else
	    {
		    stickinput = new Vector2(0, 0);
		    if (Input.GetKey(KeyCode.W)
			    stickinput += new Vector2(0, 1);
		    if (Input.GetKey(KeyCode.S)
			    stickinput += new Vector2(0, -1);
		    if (Input.GetKey(KeyCode.A)
			    stickinput += new Vector2(-1, 0);
		    if (Input.GetKey(KeyCode.D)
			    stickinput += new Vector2(1, 0);
	    }
		    
		    transform.Translate(stickinput.normalized * speed * Time.fixedDeltaTime, Space.Self);
		    // or use the one commented out below
		    // rigidbody2D.AddForce(stickinput.normalized * speed * Time.fixedDeltaTime);
	
	}
