    protected override void Update(GameTime gameTime)
    {
        keystate = Keyboard.GetState();
        if (keystate.IsKeyDown(Keys.Right))
            spritePosition.X += spriteSpeed.X;
    }
