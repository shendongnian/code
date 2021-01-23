    public const string REGEX_NUMERIC = @"^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$";
    private static Dictionary<string, Regex> regexes = new Dictionary<string, Regex>();
    public static bool IsExactMatch(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input)) return false;
        Regex regex;
        if (!regexes.TryGetValue(pattern, out regex))
        {
            regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            regexes.Add(pattern, regex);
        }
        Match m = regex.Match(input);
        if (!m.Success) return false;
        return m.Groups[0].Value == input;
    }
