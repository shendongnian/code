    public static IEnumerable<IEnumerable<T>> SplitOn<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        return source.Aggregate(Enumerable.Repeat(Enumerable.Empty<T>(), 1),
                                (list, value) =>
                                    {
                                        list.Last().Concat(Enumerable.Repeat(value, 1));
                                        return predicate(value) ? list.Concat(Enumerable.Repeat(Enumerable.Empty<T>(), 1)) : list;
                                    });
    }
