    public static IEnumerable<IImmutableList<TSource>> GroupByDelimited<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> startDelimiter,
        Func<TSource, bool> endDelimiter,
        bool includeUndelimited = false)
    {
        var delimited = default(ImmutableList<TSource>.Builder);
        var undelimited = default(ImmutableList<TSource>.Builder);
        foreach (var item in source)
        {
            if (delimited == null)
            {
                if (startDelimiter(item))
                {
                    if (includeUndelimited && undelimited != null)
                    {
                        yield return undelimited.ToImmutable();
                        undelimited = null;
                    }
                    delimited = ImmutableList.CreateBuilder<TSource>();
                }
                else if (includeUndelimited)
                {
                    if (undelimited == null)
                    {
                        undelimited = ImmutableList.CreateBuilder<TSource>();
                    }
                    undelimited.Add(item);
                }
            }
            if (delimited != null)
            {
                delimited.Add(item);
                if (endDelimiter(item))
                {
                    yield return delimited.ToImmutable();
                    delimited = null;
                }
            }
        }
    }
