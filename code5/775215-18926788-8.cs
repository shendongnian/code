    public static IEnumerable<T> Repeat<T>(this ICollection<T> lst, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("count");
        var ret = Enumerable.Empty<T>();
        for (var i = 0; i < count; i++)
            ret = ret.Concat(lst);
        return ret;
    }
