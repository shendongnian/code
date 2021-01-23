    private static IEnumerable<string> MakeDesiredSize(
        List<string> items, int desiredSide)
    {
        var lookup = items.Where(item => item.Length <= desiredSide)
            .ToLookup(item => item.Length);
        return Enumerable.Range(0, desiredSide / 2)
                .SelectMany(i => lookup[i].Zip(lookup[desiredSide - i]
                    , (a, b) => a + b))
                .Concat(lookup[desiredSide]);
    }
