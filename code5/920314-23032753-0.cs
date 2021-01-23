    void UpdateSprite(GameTime gameTime)
    {
        // Move the sprite by speed, scaled by elapsed time.
        spritePosition +=
            spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    
        int MaxX =
            graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
        int MinX = 0;
        int MaxY =
            graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
        int MinY = 0;
    
        // Check for bounce.
        if (spritePosition.X > MaxX)
        {
            spriteSpeed.X *= -1;
            spritePosition.X = MaxX;
        }
    
        else if (spritePosition.X < MinX)
        {
            spriteSpeed.X *= -1;
            spritePosition.X = MinX;
        }
    
        if (spritePosition.Y > MaxY)
        {
            spriteSpeed.Y *= -1;
            spritePosition.Y = MaxY;
        }
    
        else if (spritePosition.Y < MinY)
        {
            spriteSpeed.Y *= -1;
            spritePosition.Y = MinY;
        }
    }
