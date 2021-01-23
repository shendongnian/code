    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            heldDownW = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            heldDownW = false;
        }
    }
    
    void FixedUpdate()
    {
         if(heldDownW)
         {
             rigidbody.MovePosition(new Vector3(transform.position.x, (transform.position.y + 10f * Time.deltaTime), transform.position.z));
         }
    }
