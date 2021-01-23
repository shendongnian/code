    public static string GetLongestCommonSubstring(this IList<string> strings)
    {
        if (strings == null)
            throw new ArgumentNullException("strings");
        if (!strings.Any() || strings.Any(s => string.IsNullOrEmpty(s)))
            throw new ArgumentException("None string must be empty", "strings");
        var commonSubstrings = new HashSet<string>(strings[0].GetSubstrings());
        foreach (string str in strings.Skip(1))
        {
            commonSubstrings.IntersectWith(str.GetSubstrings());
            if (commonSubstrings.Count == 0)
                return null;
        }
        return commonSubstrings.OrderByDescending(s => s.Length).First();
    }
    public static IEnumerable<string> GetSubstrings(this string str)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentException("str must not be null or empty", "str");
        for (int c = 0; c < str.Length - 1; c++)
        {
            for (int cc = 1; c + cc <= str.Length; cc++)
            {
                yield return str.Substring(c, cc);
            }
        }
    }
