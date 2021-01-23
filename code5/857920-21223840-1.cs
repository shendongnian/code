    int countdown;
    
    public void Initialize()
    {
        countdown = 120000; //120 seconds
    }
    
    public override void Update()
    {
        countdown -= gameTime.ElapsedTime.TotalMilliseconds;
    }
    
