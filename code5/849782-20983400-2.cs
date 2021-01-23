    private static Regex getNumberAndBeyondRegex = new Regex(^\D+(\d.*)$", RegexOptions.Compiled);
    public static string GetNumberAndBeyond(string input)
    {
        var match = getNumberAndBeyondRegex.Match(input);
        if (!match.Success) throw new ArgumentException("String isn't in the correct format.", "input");
        return match.Groups[1].Value;
    }
