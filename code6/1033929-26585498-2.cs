    private static int CountPatternAppearancesInString(string str, string pattern)
    {
        var count = str
            .Select(
                (_, index) =>
                    index < str.Length - pattern.Length + 1 &&
                    str.IndexOf(pattern, index, pattern.Length) >= 0)
            .Count(isMatch => isMatch);
        return count;
    }
