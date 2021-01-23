    public static void PerformAction(this Tile[,] tileMap, ActionRef<Tile> action)
    {
        for (int x = 0; x < tileMap.GetLength(0); x++)
        {
            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                action(ref tileMap[x, y]);
            }
        }
    }
