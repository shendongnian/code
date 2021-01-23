    public override void Update(GameTime gameTime)
    {
        elapsedTime = gameTime.ElapsedGameTime - last;
        
        frameRate = (double)frameCounter / elapsedTime.TotalSeconds;
        last = gameTime.ElapsedGameTime;
        frameCounter = 0;
    }
