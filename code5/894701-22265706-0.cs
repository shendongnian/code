    protected override void Draw(GameTime gameTime)
    {
      ...
      // Initialize the batch with the scaling matrix
      spriteBatch.Begin();
      // Draw a sprite at each corner
      for (int i = 0; i < spritepos.Length; i++)
      {
          spriteBatch.Draw(square, spritepos[i], null, Color.White,
              rotation, origin, scale, SpriteEffects.None, depth);
      }
      spriteBatch.End();
      base.Draw(gameTime);
    }
