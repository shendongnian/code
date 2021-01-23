    public static IEnumerable<TResult> Pairwise<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, TResult> resultSelector)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                yield break;
            var previous = iterator.Current;
            while (iterator.MoveNext())
            {
                yield return resultSelector(previous, iterator.Current);
                previous = iterator.Current;
            }
        }
    }
