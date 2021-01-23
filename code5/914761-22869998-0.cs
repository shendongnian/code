    public void Draw(SpriteBatch spriteBatch, List<stationaryFood> foodlist)
    {
        foreach (stationaryFood food in foodlist)
        {
            spriteBatch.Draw(food.CharacterImage, foodBoundingRectangle, foodColor);
        }
    }
