    KeyboardState newState = Keyboard.GetState();  // get the newest state
     
    // handle the input
    if(newState.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
    {
        playerPosition.Y += 6.0f;
    }
    if(newState.IsKeyUp(Keys.Space) && oldState.IsKeyDown(Keys.Space))
    {
        playerPosition.Y -= 6.0f;
    }
     
    oldState = newState;  // set the new state as the old state for next time
