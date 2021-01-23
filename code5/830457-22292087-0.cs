        protected override void Draw(GameTime gameTime)
        {
            RenderTarget2D renderTarget = new RenderTarget2D(GraphicsDevice, 800, 600);
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            effect.Parameters["color"].SetValue(color.Green);
            effect.CurrentTechnique.Passes[0].Apply();
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(texture, altDestRect, sourceRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
