    public IEnumerable<int> GetColorsValues(IEnumerable<string> colors)
    {
        Colors value;
        foreach (string color in colors)
            if (Enum.TryParse<Colors>(color, true, out value))
                yield return (int)value;
    }
