    public static IEnumerable<T> TakeLoop<T>(
            this IEnumerable<T> source,
            int count,
            int start = 0)
    {
        if (start < 0)
        {
            throw new ArgumentOutOfRangeException("start");
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count");
        }
        using (var m = source.GetEnumerator())
        {
            for (var i = 0; i < count + start; i++)
            {
                if (!m.MoveNext())
                {
                    if (i < start)
                    {
                        throw new ArgumentOutOfRangeException("start");
                    }
                    m.Reset();
                    m.MoveNext();
                }
                if (i >= start)
                {
                    yield return m.Current;
                }
            }
        }
    }
