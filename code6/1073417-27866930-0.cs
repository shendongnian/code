    void Update () 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded == true)
            {
                rigidbody2D.velocity = new Vector3 (0, jump, 0);
                Debug.Log ("SingleJump");
                grounded = false;
                doublejump = true;
            }
            else if (doublejump == true)
            {
                rigidbody2D.velocity = new Vector3 (0, jump, 0);
                Debug.Log ("DoubleJump");
                doublejump = false;             
           }
        }
    }
