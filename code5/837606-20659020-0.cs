    public static async Task<string> MergeRecursive(IEnumerable<string> strings)
    {
        if (strings.Count() == 1)
            return strings.First();
        if (strings.Count() == 2)
            return Merge(strings.First(), strings.Last());
        var parts = strings.Select((s, i) => new { s, i })
                           .GroupBy(g => g.i % 2, g => g.s, (k, v) => v)
                           .ToList();
        var results = await Task.WhenAll(parts.Select(p => Task.Run(() => MergeRecursive(p))));
        return await MergeRecursive(results);
    }
