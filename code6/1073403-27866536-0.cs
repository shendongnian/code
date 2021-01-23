    public static IEnumerable<Tuple<T, T>> Pairwise<T>(this IEnumerable<T> source)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                yield break;
            T prev = iterator.Current;
            while (iterator.MoveNext())
            {
                yield return Tuple.Create(prev, iterator.Current);
                prev = iterator.Current;
            }
        }
    }
