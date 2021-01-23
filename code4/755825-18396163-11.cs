    public static void ZipAll<T>(this IEnumerable<IEnumerable<T>> all, Action<IEnumerable<T>> action)
    {
        var enumerators = all.Select(e => e.GetEnumerator()).ToList();
        try
        {
            while (enumerators.All(e => e.MoveNext()))
                action(enumerators.Select(e => e.Current));
        }
        finally
        {
            foreach (var e in enumerators) 
                e.Dispose();
        }
    }
    
