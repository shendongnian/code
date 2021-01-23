    protected override void Update(GameTime gameTime)
    {
        keystate = Keyboard.GetState();
        if (keystate.IsKeyDown(Keys.right))
            spritePosition.X += spriteSpeed.X;
    }
