    private GameTime animGameTimeStart;
    public void Update(GameTime gameTime)
    {
        //When starting the animation:
        this.animGameTimeStart = gameTime;
    
        if(gameTime.ElapsedTime - animGameTimeStart.ElapsedTime <= TimeSpan.FromSeconds(2))
        { 
            //Set again to Idle
        }
    }
