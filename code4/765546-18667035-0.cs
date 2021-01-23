    public static bool ListContains<T>(List<T> source, List<T> search)
    {
        if (search.Count > source.Count)
            return false;
        return Enumerable.Range(0, source.Count - search.Count + 1)
            .Select(a => source.Skip(a).Take(search.Count))
            .Any(a => a.SequenceEqual(search));
    }
    public static void Main(string[] args)
    {
        var masterList = new List<string> { "fox", "jumps", "dog" };
        var childList1 = new List<string> { "fox", "jumps" };
        var childList2 = new List<string> { "fox", "dog" };
        Console.WriteLine(ListContains(masterList, childList1));
        Console.WriteLine(ListContains(masterList, childList2));
    }
