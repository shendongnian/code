	void FixedUpdate () 
	{
	    
		if (Options.useController)
		{
            // if the controller is enabled do this stuff
	      	Vector2 stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
	    else
	    {
            // else if the controller is not enabled, do this stuff.
		    stickinput = new Vector2(0, 0);
		    if (Input.GetKey(KeyCode.W)
			    stickinput += new Vector2(0, 1);
		    if (Input.GetKey(KeyCode.S)
			    stickinput += new Vector2(0, -1);
		    if (Input.GetKey(KeyCode.A)
			    stickinput += new Vector2(-1, 0);
		    if (Input.GetKey(KeyCode.D)
			    stickinput += new Vector2(1, 0);
            /* can have code like:
             * if (stickinput.x > 0)
             *     animator.crossfade("rightAnimation", 0f);
             * else if (stickinput.x < 0)
             *     animator.crossfade("leftanimation", 0f);
             * else
             *     animator.crossfade("standinganimation", 0f);
             */
	    }
		    
		    transform.Translate(((stickinput.magnitude > 1) ? stickinput.normalized : stickinput) * speed * Time.fixedDeltaTime, Space.Self);
		    // or use the one commented out below
		    // rigidbody2D.AddForce(((stickinput.magnitude > 1) ? stickinput.normalized : stickinput) * speed * Time.fixedDeltaTime);
	
	}
