    public IEnumerable<Color> InfiniteColors()
    {
        while (true)
        {   
            foreach (var color in RowColors)
            {
                yield return color;
            }
        }
    }
