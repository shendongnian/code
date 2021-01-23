    public static IEnumerable<int> GetInts(string[] a)
    {
        int i = 0;
        return a.Where(s => int.TryParse(s, out i)).Select(s => i);
    }
