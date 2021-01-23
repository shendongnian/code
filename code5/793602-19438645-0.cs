        public void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && clicked == False && button.buttonRectangle.Contains(new Point(currentMouseState.X, currentMouseState.Y)))
            {
                amountOfCats++;
                clicked = True;
            }
            else 
            {
                clicked = False
            }
            // Not needed - previousMouseState = currentMouseState;
        }
