    public static IEnumerable<IEnumerable<int>> GetCombinations(IEnumerable<int> counters)
    {
        if (counters.Any() == false)
        {
            // Base case.
            yield return Enumerable.Empty<int>();
        }
        else
        {
            int first = counters.First();
            IEnumerable<int> remaining = counters.Skip(1);
            IEnumerable<IEnumerable<int>> tails = GetCombinations(remaining);
            for (int i = 0; i < first; ++i)
                foreach (IEnumerable<int> tail in tails)
                    yield return Yield(i).Concat(tail);
        }
    }
    // Per http://stackoverflow.com/q/1577822
    public static IEnumerable<T> Yield<T>(T item)
    {
        yield return item;
    }
