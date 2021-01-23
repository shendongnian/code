    keystate = Keyboard.GetState();
    
    if (keystate.IsKeyDown(Keys.Space) && playerPosition.Y >= MinYPos)
    {
           playerPosition.Y -= 6.0f;
    }
    
    if (keystate.IsKeyUp(Keys.Space) && playerPosition.Y <= MaxYPos)
    {
            playerPosition.Y += 6.0f;
    }
