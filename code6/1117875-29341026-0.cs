    var textures = new Texture2D[]
    {
        Content.Load<Texture2D>("texture0"),
        // others
        Content.Load<Texture2D>("texture18")
    }
    
    int[][] tilesPosition = new int[][]
    {
        new[] {0, 0, 0, 0, 0, 0, 0},
        // others
        new[] {0, 0, 1, 2, 3, 4, 0},
        // others
        new[] {18, 18, 18, 18, 18, 18, 18}
    };
    for (int y = 0; y < tilesPosition.Length; y++)
    {
        for (int x = 0; x < tilesPosition[x].Length; x++)
        {
            var texture = Textures[tilesPosition[y][x]];
            Vector2 position = new Vector2(x * texture.Width,y * texture.Height)
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
