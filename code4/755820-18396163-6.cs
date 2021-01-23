    public static void ZipDo<T1, T2>( this IEnumerable<T1> first, IEnumerable<T2> second, Action<T1, T2> action)
    {
        using (var e1 = first.GetEnumerator())
        using (var e2 = second.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext())
            {
                action(e1.Current, e2.Current);
            }
        }
    }
