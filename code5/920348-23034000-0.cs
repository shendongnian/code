    protected override void Update(GameTime gameTime)
    {
        GamePadState currentState2 = GamePad.GetState(PlayerIndex.One);
        if (currentState2.IsConnected
             && currentState2.Buttons.A
                    == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
        {
             play1stTrack();
             isButtonApressed = true;
        }
        //Handle input with isButtonApressed
    }
