    public static IEnumerable<T> WhereEnabled<T>(
        this IEnumerable<T> source,
        IEnumerable<bool> flags)
    {
        using(var sourceIter = source.GetEnumerator())
        using(var flagIter = flags.GetEnumerator())
        {
            while(sourceIter.MoveNext() && flagIter.MoveNext())
            {
                if (flagIter.Current) yield return sourceIter.Current;
            }
        }
    }
