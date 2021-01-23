    public static bool CountMoreThan<TSource>(this IEnumerable<TSource> source, int num)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (num < 0)
            throw new ArgumentException("num must be greater or equal 0", "num");
        ICollection<TSource> collection = source as ICollection<TSource>;
        if (collection != null)
        {
            return collection.Count > num;
        }
        ICollection collection2 = source as ICollection;
        if (collection2 != null)
        {
            return collection2.Count > num;
        }
        int count = 0;
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
            while (++count <= num + 1)
                if (!enumerator.MoveNext())
                    return false;
        }
        return true;
    }
