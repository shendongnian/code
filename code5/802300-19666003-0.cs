    private string Pattern = "whateverregexpatternyouhavewritten";
    private bool MatchesPattern(string input)
    {
        return Regex.IsMatch(Pattern, input);
    }
