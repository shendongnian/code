    public static IEnumerable<IList<T>> Transpose<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        var enumerators = source.Select(e => e.GetEnumerator()).ToArray();
        try
        {
            while (enumerators.All(e => e.MoveNext()))
            {
                yield return enumerators.Select(e => e.Current).ToArray();
            }
        }
        finally
        {
            Array.ForEach(enumerators, e => e.Dispose());
        }
    }
    // e.g. 
    IList<IList<int>> l = new int[3][];
    l[0] = new []{0,1,2,3};
    l[1] = new []{4,5,6,7};
    l[2] = new []{8,9,10,11};
    l = l.Transpose().ToList();
    // l is { { 0, 4, 8 }, { 1, 5, 9 }, ... }
