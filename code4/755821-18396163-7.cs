    public static void ZipDo<T1, T2, T3>(this IEnumerable<T1> first,
        IEnumerable<T2> second, IEnumerable<T3> third,
        Action<T1, T2, T3> action)
    {
        using (var e1 = first.GetEnumerator())
        using (var e2 = second.GetEnumerator())
        using (var e3 = third.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
            {
                action(e1.Current, e2.Current, e3.Current);
            }
        }
    }
    
