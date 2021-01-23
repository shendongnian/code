    Draw(SpriteBatch spriteBatch, GraphicsDevice device)
    {
        Point tempPoint;
        foreach (enemy1 enemy in enemies1)
        {
            tempPoint = new Point((int)enemy.Position.X, (int)enemy.Position.Y)
            if (device.Viewport.Bounds.Contains(tempPoint))
                enemy.Draw(spriteBatch);
        }
    }
