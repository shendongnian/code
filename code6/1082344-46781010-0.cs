    public static IEnumerable<string> Split(string input, string pattern, RegexOptions options = RegexOptions.None)
    {
        // Always compile - we expect many executions
        var regex = new Regex(pattern, options | RegexOptions.Compiled);
        int currentSplitStart = 0;
        var match = regex.Match(input);
        while (match.Success)
        {
            yield return input.Substring(currentSplitStart, match.Index - currentSplitStart);
            currentSplitStart = match.Index + match.Length;
            match = match.NextMatch();
        }
        yield return input.Substring(currentSplitStart);
    }
