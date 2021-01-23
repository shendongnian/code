    public static string JoinFormat<T>(this IEnumerable<T> items,string format)
    {
        var builder = new StringBuilder();
        var result = (items.Aggregate(builder,
                (bld, c) => bld.AppendFormat(format, c),
                bld => bld.Remove(bld.Length - 1, 1))
             ).ToString();
        return result;
    }
