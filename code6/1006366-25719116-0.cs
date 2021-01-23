    Vector3 startPos;
    GameObject hitObject;
    
    void Update()
    {
    	if (Input.touchCount > 0)
    	{
    		if (Input.GetTouch(0).phase == TouchPhase.Began)
    		{
    			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    			Vector2 touchPos = new Vector2(wp.x, wp.y);
    			Collider2D hit = Physics2D.OverlapPoint(touchPos);
    
    			if (hit != null)
    			{
    				hitObject = hit.collider2D.gameObject;
    				startPos = Input.GetTouch(0).position;
    			}
    		}
    
    		if (Input.GetTouch(0).phase == TouchPhase.Ended)
    		{
    			if (hitObject != null)
    			{
    				float swipeDirection = Mathf.Sign(Input.GetTouch(0).position.y - startPos.y);
    
    				if (swipeDirection > 0)
    				{
    					Destroy(hitObject);
    				}
    				else if (swipeDirection < 0)
    				{
    
    				}
    				hitObject = null;
    			}
    		}
    	}
    }
