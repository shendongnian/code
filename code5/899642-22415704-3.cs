    public static IEnumerable<string> Foo(IEnumerable<string> data)
    {
        return data.Select(item => new
                {
                    Prefix = item.Substring(0, 2),
                    Number = int.Parse(item.Substring(2))
                })
                .GroupBy(item => item.Prefix)
                .SelectMany(group => group.OrderBy(item => item.Number)
                        .GroupWhile((prev, current) =>
                            prev.Number + 1 == current.Number)
                        .Select(range =>
                            RangeAsString(group.Key,
                                range.First().Number,
                                range.Last().Number)));
    }
