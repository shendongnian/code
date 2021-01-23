    public float speed;
	void Update()
	{	
		float verticalAxis = Input.GetAxis("Vertical");
		if (verticalAxis > 0 && verticalAxis < 1)
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
	}
