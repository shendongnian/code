    public static string MyJoin<T>(this IEnumerable<T> items)
    {
        if (typeof(T) == typeof(string)
        {
            return items.Cast<string>().MyStringJoin();
        }
        if (typeof(T).GetInterfaces().Contains(typeof(IEnumerable<>))
        {
            // recursive call
            return items.Select(x => x.Cast<object>().MyJoin());
        }
        throw new InvalidOperationException("Type is not a (nested) enumarable of strings")
    }
    public static string MyStringJoin(this IEnumerable<string> strings)
    {
        return string.Join(Environment.NewLine, strings);
    }
