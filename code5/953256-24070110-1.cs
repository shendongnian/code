    private static IList<IDictionary<int, string>> exampleFunc()
    {
        var list = new List<Dictionary<int, string>>();
        list.Add(new Dictionary<int, string>());
        return list.Cast<IDictionary<int, string>>().ToList();
    }
