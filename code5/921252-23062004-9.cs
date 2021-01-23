    class Tile
    {
        Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, tileWidth, tileHeight);
            }
        }
    }
    class MovingPlatform
    {
        Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, platformWidth, platformHeight);
            }
        }
    
        //returns true if this platform intersects the specified tile
        bool IntersectsTile(Tile tile)
        {
            return Bounds.Intersects(tile.Bounds);
        }
    }
