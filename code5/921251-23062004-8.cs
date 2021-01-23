    class Map
    {
        void LoadLevel(int level)
        {
            //Vertical Moving Platform
            if (Levels[level][y, x] == '=')
            {
                Platforms.Add(new MovingPlatform(this, ...));
            }
        }
    }
