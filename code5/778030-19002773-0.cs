    private bool dblJump = true;
    void Jump()
    {
        if (grounded == true)
        {
            rigidbody.AddForce(Vector3.up* jumpSpeed);
            grounded = false;
        } 
        else if (!grounded && dblJump)
        {
            rigidbody.AddForce(Vector3.up* jumpSpeed);
            dblJump = false;
        }
    }
    void OnCollisionEnter (Collision hit)
    {
        grounded = true;
        dblJump = true;
        // check message upon collition for functionality working of code.
        Debug.Log ("I am colliding with something");
    }
