    public static string ReplaceTitle(string input, string newTitle)
    {
        string findPattern = @"(?<prepend><title\s+value\s*=\s*\"")([^\""]*)(?<append>\"")";
        string replacePattern = "${prepend}" + newTitle + "${append}";
        return Regex.Replace(input, findPattern, replacePattern, RegexOptions.IgnoreCase);
    }
