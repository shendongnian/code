    public override void Update(GameTime gameTime)
    {
        Velocity = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
            Velocity = new Vector2(0, -0.5f);
    
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
            Velocity = new Vector2(0, 0.5f);
    
        base.Update(gameTime);
    }
