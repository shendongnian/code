            //Update() method
            if (CurrentGameState == gameState.gameLoading)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    graphics.ToggleFullScreen(); //?
                }
                graphics.ApplyChanges();
            }
