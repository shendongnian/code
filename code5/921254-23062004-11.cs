    class Map
    {
        List<Tile> _collidableTiles;
        void Update(GameTime gameTime)
        {
            foreach (MovingPlatform platform in MovingPlatforms)
            {
                platform.Update(_collidableTiles);
            }
        }
    }
