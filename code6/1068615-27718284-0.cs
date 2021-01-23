    public List<int> GetColorInts(IEnumerable<string> myColors)
    {
        return myColors
            .Select(x => Enum.Parse(typeof(Colors), x, true))
            .Cast<int>()
            .ToList();
    }
