    private static string ReplaceTailWithStars(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";
        return s.First() + string.Concat(s.Skip(1).Select(c => '*'));
    }
