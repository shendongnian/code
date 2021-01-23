    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // Start drawing
        spriteBatch.Begin();
        player.Draw(spriteBatch);
        // Stop drawing
        spriteBatch.End();
        base.Draw(gameTime);
    }
