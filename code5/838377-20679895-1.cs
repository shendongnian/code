        protected override void Draw(GameTime gameTime)
        {
             var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
             _frameCounter.Update(deltaTime);
             var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);
             _spriteBatch.DrawString(_spriteFont, fps, new Vector2(1, 1), Color.Black);
            // other draw code here
        }
