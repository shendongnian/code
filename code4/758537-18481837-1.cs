    static IEnumerable<string> EnumerateA()
    {
        return
            Enumerable.Concat(
                Enumerable.Return("1"),
                EnumerateB("2"),
                EnumerateB("3"));
    }
