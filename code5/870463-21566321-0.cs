    float cooldowntime = 0;
    Update(GameTime gameTime)
    {
        GamePadState controller = GamePad.GetState(PlayerIndex.One);
    
        cooldowntime += gameTime.ElapsedGameTime.TotalMilliseconds; 
        //if you are using XNA 3.1 or earlier, use GameTime.ElapsedRealTime
    
        if(cooldowntime >= 5000 && controller.Buttons.A == ButtonState.Pressed)
        {
             UseAbility();
             cooldowntime = 0;
        }
    }
