    public override void Update(GameTime gameTime)
    {
        elapsedTime = gameTime.ElapsedGameTime - last;
        
        if(elapsedTime.TotalSeconds > 0.0)
        {
            frameRate = (double)frameCounter / elapsedTime.TotalSeconds;
        }
        last = gameTime.ElapsedGameTime;
        frameCounter = 0;
    }
