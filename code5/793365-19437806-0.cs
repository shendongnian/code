    public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, 
                                                         Func<T, bool> delimiterPredicate,
                                                         bool includeEmptyEntries = false, 
                                                         bool includeSeparator = false)
    {
        var l = new List<T>();
        foreach (var x in source)
        {
            if (!delimiterPredicate(x))
                l.Add(x);
            else
            {
                if (includeEmptyEntries || l.Count != 0)
                {
                    if (includeSeparator)
                        l.Add(x);
                    yield return l;
                }
                l = new List<T>();
            }
        }
        if (l.Count != 0 || includeEmptyEntries)
            yield return l;
    }
