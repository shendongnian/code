    IList<string> SplitSqlStatements(string sqlScript)
    {
        // Split by "GO" statements
        var statements = Regex.Split(
                sqlScript,
                @"^\s*GO\s* ($ | \-\- .*$)",
                RegexOptions.Multiline |
                RegexOptions.IgnorePatternWhitespace |
                RegexOptions.IgnoreCase).ToList();
        // Trim each statement
        for (var i = 0; i < statements.Count; i++)
            statements[i] = statements[i].Trim(' ', '\r', '\n');
        // Remove any empty statements
        statements.RemoveAll(s => s.Trim().Length == 0);
        return statements;
    }
