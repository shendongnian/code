    public static string ToCommaList<T>(this IEnumerable<T> val)
    {
        if (!val.Any())
            return string.Empty;
        return String.Join(",", val.Select(a => a.ToString()))
    }
