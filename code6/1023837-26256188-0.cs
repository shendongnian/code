    for (int y = 0; y < Height; ++y)
    {
        for (int x = 0; x < Width; ++x)
        {
             string type = lines[y].Substring(x*2,2);
             tiles[x, y] = LoadTile(type, x, y);
        }
    }
