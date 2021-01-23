    public static string cleaner(string str)
    {
        return Regex.Replace(str, "(?<a>[áàâ]+)|(?<e>[éèê]+)", onMatch, RegexOptions.Compiled);
    }
    private static string onMatch(Match m)
    {
        if (m.Groups["a"].Success)
            return "a";
        if (m.Groups["e"].Success)
            return "e";
        return "";
    }
