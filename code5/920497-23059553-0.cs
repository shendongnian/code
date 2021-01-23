    protected override void Update(GameTime gameTime)
        {
            if (false) //<--- The answer is false, let's not run this code block!
            {
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
                ProcessNetworkMessages();
                if (!IsHost)
                {
                    KeyboardState newState = Keyboard.GetState();
                    localPlayer.Update(gameTime, oldState, newState, board);
                }
                base.Update(gameTime);
            } // Start running code from here -->
        }
