    private float lastTimeCreated;
    private float timeBetweenCreation;
    ...
    void Start()
    {
        // Initial time between object creation
        this.timeBetweenCreation = 1f;
    }
    void Update()
    {
        float now = Time.time;
        // Check if it's time to create a new object
        if (now - this.lastTimeCreated > this.timeBetweenCreation)
        {
            this.NewSpider();
            // Object created, so set new lastTimeCreated
            this.lastTimeCreated = now;
            // Some logic to change your timeBetweenCreation.  Do it here or in NewSpider().
            // this.timeBetweenCreation = ...
        }
    }
    void NewSpider ()
    {
        // Mostly what you had
        position = new Vector3(transform.position.x, Random.Range(-4.5f,4.5f), 0);
        Debug.Log("Instantiated");
        var Spider = Instantiate(xSpider, position, Quaternion.identity) as GameObject;
        if(transform.position.x>=11.0f){
            Spider.rigidbody2D.velocity = new Vector2(-1.0f * Random.Range(minimumSpeed, 6.0f), 0.0f);
        }
        else if(transform.position.x<=-11.0f){
            Spider.rigidbody2D.velocity = new Vector2(1.0f * Random.Range(minimumSpeed, 6.0f), 0.0f);
        }
        
        // Some logic to change your timeBetweenCreation.  Do it here or in Update().
        // this.timeBetweenCreation = ...
    }
