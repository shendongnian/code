    // Having a "bool leftDirectionOnLastMovement;" (worst name ever seen)
    private void CheckKeyboardAndUpdateMovement()
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyUp(Keys.Left) && leftDirectionOnLastMovement)
            ChangeTexture(1);
        if (keyboardState.IsKeyUp(Keys.Right) && !leftDirectionOnLastMovement)
            ChangeTexture(2);
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            Movement -= Vector2.UnitX;
            ChangeTexture(3);
            leftDirectionOnLastMovement = true;
        }
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            Movement += Vector2.UnitX;
            ChangeTexture(4);
            leftDirectionOnLastMovement = false;
        }
        }
        if ((keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Up)) && IsOnFirmGround())
        {
            Movement = -Vector2.UnitY * JumpHeight;
        }
    }
