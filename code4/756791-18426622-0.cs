        var match = Regex.Matches(dbContents, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        for (int i = 0; i < 3 && match.Success; i++)
        {
            Contents += String.Format("... {0} ...", matches[i].Value);
            match = match.NextMatch();
        }
