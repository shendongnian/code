    gVertNums.RowDefinitions.Clear();
    for (int i = 1; i <= numHorizLines - 1; i++)
        {
            RowDefinition r = new RowDefinition();
            r.Height = new GridLength(Convert.ToDouble(size), GridUnitType.Star);
            gVertNums.RowDefinitions.Add(r);
        }
