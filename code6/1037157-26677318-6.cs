    public static IEnumerable<int> GetInts(IEnumerable<string> strings)
    {
        int i = 0;
        return strings.Where(s => int.TryParse(s, out i)).Select(s => i);
    }
