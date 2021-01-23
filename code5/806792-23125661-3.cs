    public static bool IsOrdered<T>(
        this IEnumerable<T> source, Func<T, T, int> comparer)
    {
        return source.SelectPairs().All(t => comparer(t.Item1, t.Item2) > 0);
    }
    bool isOrdered = myCollection
        .IsOrdered((o1, o2) => o2.MyProperty - o1.MyProperty);
