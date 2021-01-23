    protected override void Update(GameTime gameTime)
    {
        // ...
        if (CheckInput(Keys.Enter, 1))
        {
            blocks = newMap(map, blocks, console);
        }
        oldState = Keyboard.GetState();
        // ...
    }
    // Method: Checks if a key is/was pressed
    public bool CheckInput(Keys key, int checkType)
    {
        // Get current keyboard state
        KeyboardState newState = Keyboard.GetState();
        bool retType = false; // Return type
        if (checkType == 0)
        {
            // Check Type: Is key currently down?
            if (newState.IsKeyDown(key))
            {
                retType = true;
            }
            else
            {
                retType = false;
            }
        }
        else if (checkType == 1)
        {
            // Check Type: Was the key pressed?
            if (newState.IsKeyDown(key))
            {
                if (!oldState.IsKeyDown(key))
                {
                    // Key was just pressed
                    retType = true;
                }
                else
                {
                    // Key was already pressed, return false
                    retType = false;
                }
            }
        }
        // Return result
        return retType;
    }
