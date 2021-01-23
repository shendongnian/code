    public bool IsGrounded;
    
    	void OnCollisionStay (Collision collisionInfo)
	{
		IsGrounded = true;	
	}
	
	void OnCollisionExit (Collision collisionInfo)
	{
		IsGrounded = false;
	}
    	
	if (Input.GetButtonDown ("Jump") && IsGrounded)
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
		}
