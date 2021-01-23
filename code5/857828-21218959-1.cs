        //this variable store the current texture index that will be displayed
        private int currentRep = 0;
        public void Update(GameTime gameTime)
        {
            if (activeCharacter.DestY >= 600)
            {
                currentRep++;
                //this line makes sure the current number doesn't point to an index higher than the number of items stored inside your list
                currentRep %= RepMeter.Count;
            }
        }
        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(RepMeter[currentRep], new Vector2(690, 29), Color.White);
            spriteBatch.End();
        }
