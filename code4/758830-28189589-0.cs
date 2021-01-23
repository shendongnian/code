    public static bool GetIdenticProperty<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> predicate)
    {
        IEnumerable<TSource> enumerable = source as IList<TSource> ?? source.ToList();
        if ((!enumerable.Any()) || (enumerable.Count() == 1))
            return true; // or false if you prefere
        var firstItem = enumerable.First();
        bool allSame = enumerable.All(i => Equals(predicate(i), predicate(firstItem)));
        return allSame;
    }
