    public float xMin, xMax, yMin, yMax;
    void Update()
    {
        //tilt to move ship
        transform.Translate(Input.acceleration.x * speed * Time.DeltaTime, Input.acceleration.y * speed * Time.DeltaTime, 0);
    
        //create boundries
        rigidbody2D.position = new Vector2(
            Mathf.Clamp(rigidbody2D.position.x, xMin, xMax), 
            Mathf.Clamp(rigidbody2D.position.y, yMin, yMax)
        );
    }
