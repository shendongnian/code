    public static string Strip(
            this string  source,
            params char[] exclusions)
    {
        if (!exclusions.Any())
        {
            return source;
        }
        var mask = new HashSet<char>(exclusions);
        var result = new StringBuilder(source.Length);
        foreach (var c in source.Where(c => !mask.Contains(c)))
        {
            result.Append(c);
        }
        return result.ToString();
    }
