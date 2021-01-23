    public static string MyJoin(this IEnumerable<IEnumerable<IEnumerable<string>>> items)
    {
        return items.SelectMany(x => x).MyJoin();
    }
    public static string MyJoin(this IEnumerable<IEnumerable<string>> items)
    {
        return items.SelectMany(x => x).MyJoin();
    }
    public static string MyJoin(this IEnumerable<string> strings)
    {
        return string.Join(Environment.NewLine, strings);
    }
