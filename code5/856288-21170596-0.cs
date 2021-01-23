    [XmlIgnore]
    public Tile[,] Tiles { get; set; }
    
    [XmlElement("Tile")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public List<Tile> TileList
    {
        /* existing code */
        set
        {
            Tiles = new Tile[MapWidth, MapHeight];
            for(int i=0;i < value.Count;i++) {
                int x = i % mapWidth;
                int y = i / mapWidth; // integer division always "rounds down"
    
                Tiles[x, y] = value[i];
            }
        }
    }
