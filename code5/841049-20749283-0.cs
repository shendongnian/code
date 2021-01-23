    static bool Parse(string pattern, string text, out string[] wildcardValues)
    {
        // ^ and $ means that whole string must be matched
        // Regex.Escape (http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.escape(v=vs.110).aspx)
        // (.+) means capture at least one character and place it in match.Groups
        var regexPattern = string.Format("^{0}$", Regex.Escape(pattern).Replace(@"\*", "(.+)"));
        var match = Regex.Match(text, regexPattern, RegexOptions.Singleline);
        if (!match.Success)
        {
            wildcardValues = null;
            return false;
        }
        //skip the first one since it is the whole text
        wildcardValues = match.Groups.Cast<Group>().Skip(1).Select(i => i.Value).ToArray();
        return true;
    }
