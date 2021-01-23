    clone.values = new double[][][values.Length];
    for (int i = 0; i < values.Length, i++)
    {
        clone.values[i] = new double[][values[i].Length];
        for (int j = 0; j < values[i].Length; j++)
        {
            clone.values[i][j] = values[i][j].Clone();
        }
    }
