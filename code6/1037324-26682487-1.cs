    public float xMin, xMax, yMin, yMax;
    void Update()
    {
        //tilt to move ship
        transform.Translate(Input.acceleration.x * speed * Time.DeltaTime, Input.acceleration.y * speed * Time.DeltaTime, 0);
    
        //create boundries
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, xMin, xMax), 
            Mathf.Clamp(transform.position.y, yMin, yMax)
        );
    }
