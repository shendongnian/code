    /// <summary>
    /// Projects two consecutive pair of items into tuples.
    /// {1,2,3,4} -> {(1,2), (2,3), (3,4))
    /// </summary>
    public static IEnumerable<Tuple<T, T>> SelectPairs<T>(this IEnumerable<T> source)
    {
        return SelectPairs(source, (t1, t2) => new Tuple<T, T>(t1, t2));
    }
    /// <summary>
    /// Projects two consecutive pair of items into a new form.
    /// {1,2,3,4} -> {pairCreator(1,2), pairCreator(2,3), pairCreator(3,4))
    /// </summary>
    public static IEnumerable<TResult> SelectPairs<T, TResult>(
        this IEnumerable<T> source, Func<T, T, TResult> pairCreator)
    {
        T lastItem = default(T);
        bool isFirst = true;
        foreach (T currentItem in source)
        {
            if (!isFirst)
            {
                yield return pairCreator(lastItem, currentItem);
            }
            isFirst = false;
            lastItem = currentItem;
        }
    }
