    static IEnumerable<T> TakeMaskedItemsByIndex(this IEnumerable<T> collection, ulong mask)
    {
        foreach (T item in collection)
        {
            if((mask & 1) == 1)
                yield return item;
            mask = mask >> 1;
        }
    }
