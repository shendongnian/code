    // This should restrict your code to running once per 100 ticks
    if (gameTime.ElapsedGameTime.Ticks % 100 == 0)
    {
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            _engine.SpreadFire();
        }
    
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            _engine.InitializeBoardStates(5);
            SuppressDraw();
        }
    }
