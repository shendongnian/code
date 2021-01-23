	void Update()
	  {
		// Movement
		Vector3 movement = new Vector3(
		  speed.x * direction.x,
		  speed.y * direction.y,
		  0);
		movement *= Time.deltaTime;
		transform.Translate(movement);
		// Move the camera
		if (isLinkedToCamera)
		{
		  Camera.main.transform.Translate(movement);
		}
	  }
