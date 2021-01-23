    enum Direction { Left = 1, Right = 2}
    Direction dir = Direction.Left; //or whatever
    private void CheckKeyboardAndUpdateMovement()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        
        ChangeTexture((int)dir);
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            Movement -= Vector2.UnitX;
            ChangeTexture(3);
            dir = Direction.Left;
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            Movement += Vector2.UnitX;
            ChangeTexture(4);
            dir = Direction.Right;
        }
        if ((keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Up)) && IsOnFirmGround())
        {
            Movement = -Vector2.UnitY * JumpHeight;
        }
    }
