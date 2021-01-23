    private static IEnumerable<string> SplitSqlStatements(string sqlScript)
    {
        // Split by "GO" statements
        var statements = Regex.Split(
                sqlScript,
                @"^\s*GO\s*\d*\s*(?:--.*)?$",
                RegexOptions.Multiline |
                RegexOptions.IgnorePatternWhitespace |
                RegexOptions.IgnoreCase);
        // Remove empties, trim, and return
        return statements
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim(' ', '\r', '\n'));
    }
