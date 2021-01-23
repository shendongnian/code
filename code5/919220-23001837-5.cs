        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for (int i = 0; i <= brickXY.Length - 1; i++)
            {
                spriteBatch.Draw(brick, brickXY[i], Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
