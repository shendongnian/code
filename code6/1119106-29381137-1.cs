    MarbleColor PickMarble
        (Random rng, int redCount, int greenCount, int blueCount, int orangeCount)
    {
        int index = rng.Next(redCount + greenCount + blueCount + orangeCount);
        if (index < redCount)
        {
            return MarbleColor.Red;
        }
        if (index < redCount + greenCount)
        {
            return MarbleColor.Green;
        }
        if (index < redCount + greenCount + blueCount)
        {
            return MarbleColor.Blue;
        }
        return MarbleColor.Orange;
    }
