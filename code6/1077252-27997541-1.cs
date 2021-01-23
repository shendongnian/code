    protected override void Update(GameTime gameTime)
    {
        if(changeresolution){
             graphics.PreferredBackBufferHeight = 1600;
             graphics.PreferredBackBufferWidth = 1800;
             graphics.ApplyChanges();
             changeresolution = false;
        }
    }
