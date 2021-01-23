    public void DrawMap(Texture2D tilesheet, SpriteBatch spriteBatch)
    {
        for (int x = 0; x < map.GetLength(1); x++)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                spriteBatch.Draw(tilesheet, new Vector2((x * 64) , (y * 64)), new Rectangle((map[x,y]%8) * 64, (map[x,y]/8)*64, 64, 64), Color.White);
            }
        }
    }
