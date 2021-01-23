    public float speed;
    
    void FixedUpdate ()
    {
        float LeftRight = 0;
        if(Input.touchCount > 0){
            // touch x position is bigger than half of the screen, moving right
            if(Input.getTouch(0).position.x > Screen.width / 2)
                LeftRight = 1;
            // touch x position is smaller than half of the screen, moving left
            else if(Input.getTouch(0).posision.x < Screen.width / 2)
                LeftRight = -1;
        }
    
        Vector3 Movement = new Vector3 ( LeftRight, 0, 0);
    
        rigidbody.AddForce(Movement * speed);
    }
