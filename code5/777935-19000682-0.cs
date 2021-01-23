    public static string Strip(
            this string  source,
            IEnumerable<char> exclusionSequence)
    {
        var exclusions = new HashSet<char>(exclusionSequence);
        var result = new StringBuilder(source.Length);
        foreach (var c in source.Where(c => !exclusions.Contains(c)))
        {
            result.Append(c);
        }
        return result.ToString();
    }
