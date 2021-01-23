    public static IEnumerable<T> intersectAll<T>(IEnumerable<IEnumerable<T>> source)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                return Enumerable.Empty<T>();
            var set = new HashSet<T>(iterator.Current);
            while (iterator.MoveNext())
                set.IntersectWith(iterator.Current);
            return set;
        }
    }
