    public override Texture2D Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.SetRenderTarget(gameRenderTarget);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null);
            sky.Draw(spriteBatch);
            ground.Draw(spriteBatch);
            background.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            return (Texture2D)finalRenderTarget;
        }
