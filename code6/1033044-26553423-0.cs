    protected override void Update(GameTime gameTime)
    {
        // Modified this
        string messageString = String.Empty;
        input.messageString = String.Empty;    
    
    
        KeyboardState keyState = Keyboard.GetState();
        Keys[] pressedKeys;
        pressedKeys = keyState.GetPressedKeys();
        for (int i = 0; i < pressedKeys.Length; i++)
            messageString = messageString + pressedKeys[i].ToString() + "";
    
        // Added this - this should be what resolves the error you were getting
        input.messageString = messageString;
    
        base.Update(gameTime);
     }
