    private static Regex getNumberAndBeyondRegex = new Regex("^[^0-9]+([0-9]+.*)$", RegexOptions.Compiled);
    public static string GetNumberAndBeyond(string input)
    {
        var match = getNumberAndBeyondRegex.Match(input);
        if (!match.Success) throw new ArgumentException("String isn't in the correct format.", "str");
        return match.Groups[1].Value;
    }
