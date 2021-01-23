    public string facing = "right";
    public string previousFacing;
    private void Awake()
    {
        previousFacing = facing;
    }
    void Update()
    {
        // store movement from horizontal axis of controller
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        // call function
        DetermineFacing(move);
    }
    // determine direction of character
    void DetermineFacing(Vector2 move)
    {
        if (move.x < -0.01f)
        {
            facing = "left";
        }
        else if (move.x > 0.01f)
        {
            facing = "right";
        }
        // if there is a change in direction
        if (previousFacing != facing)
        {
            // update direction
            previousFacing = facing;
            // change transform
            gameObject.transform.Rotate(0, 180, 0);
        }
    }
