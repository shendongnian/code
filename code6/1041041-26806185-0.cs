    public Tile[] tiles;
    public PlayerData()
    {
        tiles = new Tile[40];
        for (int i = 0; i < tiles.Length; i++)
            tiles[i] = new Tile();
    }
