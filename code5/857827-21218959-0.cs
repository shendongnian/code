        int currentRep = 0;
        public void Update(GameTime gameTime)
        {
            if (activeCharacter.DestY >= 600)
            {
                currentRep++;
                currentRep %= 20;
            }
        }
        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(RepMeter[currentRep], new Vector2(690, 29), Color.White);
            spriteBatch.End();
        }
