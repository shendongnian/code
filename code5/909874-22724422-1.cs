    Texture2D sprite;
    Vector2 position;
    ...
    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(sprite, position, Color.White)
        spriteBatch.End();
    }
