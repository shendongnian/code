    public static bool IsOrdered<T, TKey>(
        this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        var comparer = Comparer<TKey>.Default;
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                return true;
            TKey current = keySelector(iterator.Current);
            while (iterator.MoveNext())
            {
                TKey next = keySelector(iterator.Current);
                if (comparer.Compare(current, next) > 0)
                    return false;
                current = next;
            }
        }
        return true;
    }
