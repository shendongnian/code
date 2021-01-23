    protected override void Draw(GameTime gameTime)
    {
        for (y = 0; y <= 19; y++)
            for (x = 0; x <= 19; x++)
                if (Map.level[x, y] != null)
                    spriteBatch.Draw(Resources.room_minimap, new Rectangle(30, 20, 30, 20), null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0f);
    }
