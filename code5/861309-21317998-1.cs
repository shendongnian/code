    private static readonly Regex boolParseRegex =
        new Regex(@"^(true|false) (and|or) (true|false)$", RegexOptions.IgnoreCase);
    public bool ParseExpression(string expr)
    {
        var res = boolParseRegex.Match(expr);
        bool val1 = bool.Parse(res.Groups[1].Value);
        bool isAnd = string.Equals(res.Groups[2].Value, "and",
                                   StringComparison.InvariantCultureIgnoreCase);
        bool val2 = bool.Parse(res.Groups[3].Value);
        return isAnd ? val1 && val2 : val1 || val2;
    }
