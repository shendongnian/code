    public override void Update(GameTime gameTime)
    {
        //everything else goes here
        
        if (key.IsKeyDown(Keys.P) && oldState.IsKeyUp(Keys.P))
        {
            //create a screen
        }
        oldState = key.GetState();
    }
