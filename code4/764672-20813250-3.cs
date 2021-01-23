        /// <summary>
        /// Draws the game objects to the screen. Calls Root.Draw.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Camera
            SpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Resolution.Scale);
            Root.Draw(SpriteBatch, gameTime);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
