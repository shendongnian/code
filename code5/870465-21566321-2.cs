    float cooldowntime = 0;
    Update(GameTime gameTime)
    {
        GamePadState controller = GamePad.GetState(PlayerIndex.One);
    
        cooldowntime = (cooldowntime >= 5000 && controller.Buttons.A == ButtonState.Pressed) ? 0 : cooldowntime + gameTime.ElapsedGameTime.TotalMilliseconds; 
        if (cooldowntime == 0) UseAbility(); 
        // we know to use the ability if cooldowntime = 0 since it will only equal zero
        // when cooldowntime >= 5000 and the button is pressed.
    }
