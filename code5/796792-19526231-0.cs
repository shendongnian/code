    void Main()
    {
        Map map = new Map();
        
        map.Width = 10;
    }
    
    class Map
    {
        public int Width { get; set; } // Width of map in tiles
        public int Height { get; set; } // Height of map in tiles
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
    }
