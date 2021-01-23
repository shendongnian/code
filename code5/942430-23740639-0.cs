    bool moveLeft = false;
    
    void FixedUpdate() 
    {
    
        if(Input.GetMouseButtonDown(0)
    		&& (Input.mousePosition.x < (Screen.width*2)/3 && Input.mousePosition.y > Screen.height/3))
        {
    		moveLeft = true;
    	}
    
    	if (moveLeft
    		&& (position == middle))
    	{
    		MoveLeft();
        }
    	else
    	{
    		moveLeft = false;
    	}
    }
    
    void MoveLeft()
    {
        var pos = rigidbody.position;
        float xPosition = left.transform.position.x;
        pos.x = Mathf.Lerp(pos.x, xPosition, speed * Time.deltaTime);
        rigidbody.position = pos;
    }
