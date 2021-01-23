    private static string AwesomeRegexReplace(string input, string sourcePattern, string targetPattern)
    {
        var targetFormat = PatternToStringFormat(targetPattern);
        return Regex.Replace(input, sourcePattern, match =>
        {
            var args = match.Groups.OfType<Group>().Skip(1).Select(g => g.Value).ToArray<object>();
            return string.Format(targetFormat, args);
        });
    }
