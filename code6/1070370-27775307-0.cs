    string ExtractClass(string fileContents, Regex classRegex, Regex nonClassRegex)
    {
        Match match1 = classRegex.Match(fileContents);
        if (!match1.Success)
        {
            return null;
        }
        Match match2 = nonClassRegex.Match(fileContents, match1.Index + match1.Length);
        if (!match2.Success)
        {
            return fileContents.Substring(match1.Index);
        }
        return fileContents.Substring(match1.Index, match2.Index - match1.Index);
    }
