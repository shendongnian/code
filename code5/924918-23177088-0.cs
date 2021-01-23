    public void spawnFloor()
    {
        for (int x = 0; x < floorSize / texture.Width; x++)
        {
            if (walls.Count < floorSize / texture.Width)
            {
                var localVal = x;
                positionModifier.X = texture.Width * localVal;
                position.Y = floorStart.Y;
                spawnWall();
            }
        }
    }
