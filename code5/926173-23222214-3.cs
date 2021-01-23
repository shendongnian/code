    public static IEnumerable<T> Intertwine<T>(this IEnumerable<T> a, IEnumerable<T> b)
    {
        using (var enumerator1 = a.GetEnumerator())
        using (var enumerator2 = b.GetEnumerator())
        {
            bool more1 = enumerator1.MoveNext();
            bool more2 = enumerator2.MoveNext();
            
            while (more1 && more2)
            {
                yield return enumerator1.Current;
                yield return enumerator2.Current;
    
                more1 = enumerator1.MoveNext();
                more2 = enumerator2.MoveNext();
            }
            
            while (more1)
            {
                yield return enumerator1.Current;
                more1 = enumerator1.MoveNext();
            }
    
            while (more2)
            {
                yield return enumerator2.Current;
                more2 = enumerator2.MoveNext();
            }
        }
    }
