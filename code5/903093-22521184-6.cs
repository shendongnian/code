        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(flippedTextureHorizontal, new Vector2(texture.Width + offset, 0), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(flippedTextureVertical, new Vector2(texture.Width * 2 + offset * 2, 0), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(flippedTextureVerticalHorizontal, new Vector2(texture.Width * 3 + offset * 3, 0), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
