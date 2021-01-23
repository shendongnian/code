    static readonly Regex re = new Regex(@"\b(\w+)\b", RegexOptions.Compiled);
    static void Main(string[] args)
    {
        string input = @"Dear Name, as of dAte your balance is amounT!";
        var replacements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"name", "Mr Smith"},
            {"date", "05 Aug 2009"},
            {"amount", "GBP200"}
        };
        string output = re.Replace(input, match => replacements.ContainsKey(match.Groups[1].Value) ? replacements[match.Groups[1].Value] : match.Groups[1].Value);
    }
