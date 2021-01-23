     KeyboardState ks = Keyboard.GetState();
     MouseState ms = Mouse.GetState();
     if (ms.LeftButton == ButtonState.Pressed)
     {
         DoWhatEver();
     }
     if (ks.IsKeyDown(Keys.Space))
     {
         AnimateShooting();
     }
