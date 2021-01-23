    public static IEnumerable<T> Mesh<T>(
        this IEnumerable<T> source,
        params IEnumerable<T>[] others)
    {
        if (others.LongLength == 0L)
        {
            foreach (var t in source)
            {
                yield return t;
            }
            yield break;
        }
        var nullCheck = Array.FindIndex(others, e => e == null);
        if (nullCheck >= 0)
        {
            throw new ArgumentNullException(string.Format(
                "Parameter {0} is null, this is not supported.",
                ++nullCheck),
                (Exception)null);
        }
        var enumerators = new[] { source.GetEnumerator() }
            .Concat(others.Select(o => o.GetEnumerator())).ToList();
        try
        {
            var finishes = new bool[enumerators.Count];
            var allFinished = false;
            while (!allFinished)
            {
                allFinsihed = true;
                for (var i = 0; i < enumerators.Count; i++)
                {
                    if (finishes[i])
                    {
                        continue;
                    }
                    
                    if (enumerators[i].MoveNext())
                    {
                            yield return enumerators[i].Current;
                            allFinished = false;
                            continue;
                    }
                    finishes[i] = true;
                }
            }
        }
        finally
        {
            foreach (var enumerator in enumerators)
            {
                enumerator.Dispose();
            }
        }   
    }
