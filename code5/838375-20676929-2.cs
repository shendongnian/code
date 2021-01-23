    public override void Update(GameTime gameTime)
    {        
        if(gameTime.ElapsedGameTime.TotalSeconds > 0.0)
        {
            frameRate = (double)frameCounter / gameTime.ElapsedGameTime.TotalSeconds;
        }
        frameCounter = 0;
    }
