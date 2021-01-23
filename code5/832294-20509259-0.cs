    private static readonly string _InnerPattern = "([a-zA-Z0-9]{2})";
    private static readonly string _Pattern = string.Format("{0}-{0}-{0}-{0}-{0}-{0}", _InnerPattern);
    private static readonly string _ReplacePattern = "$1$2.$3$4.$5$6";
    private static readonly Regex _TransformRegex = new Regex(_Pattern, RegexOptions.Compiled);
    public static string TransformMacAddressUsingRegex(string input)
    {
        return _TransformRegex.Replace(input, _ReplacePattern);
    }
