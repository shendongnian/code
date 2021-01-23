    public static IEnumerable<List<T>> SplitBy<T>(
        this IEnumerable<T> source, Func<T, bool> separator)
    {
        List<T> batch = new List<T>();
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                if (separator(iterator.Current) && batch.Any())
                {
                    yield return batch;
                    batch = new List<T>();
                }
                batch.Add(iterator.Current);
            }
        }
        if (batch.Any())
            yield return batch;
    }
