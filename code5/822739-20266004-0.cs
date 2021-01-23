    /// <summary>
    /// Given a list, return the last value from each run of similar items.
    /// </summary>
    public static IEnumerable<T> WithoutDuplicates<T>(this IEnumerable<T> source, Func<T, T, bool> similar)
    {
        Contract.Requires(source != null);
        Contract.Requires(similar != null);
        Contract.Ensures(Contract.Result<IEnumerable<T>>().Count() <= source.Count(), "Result should be at most as long as original list");
        T last = default(T);
        bool first = true;
        foreach (var item in source)
        {
            if (!first && !similar(item, last))
                yield return last;
            last = item;
            first = false;
        }
        if (!first)
            yield return last;
    }
