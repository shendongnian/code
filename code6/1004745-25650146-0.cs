    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source
        , Func<TSource, TKey> selector
        , IComparer<TKey> comparer = null)
    {
        if (comparer == null)
        {
            comparer = Comparer<TKey>.Default;
        }
        using (IEnumerator<TSource> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                throw new ArgumentException("Source was empty");
            }
    
            TSource maxItem = iterator.Current;
            TKey maxValue = selector(maxItem);
    
            while (iterator.MoveNext())
            {
                TKey nextValue = selector(iterator.Current);
                if (comparer.Compare(nextValue, maxValue) > 0)
                {
                    maxValue = nextValue;
                    maxItem = iterator.Current;
                }
            }
            return maxItem;
        }
    }
