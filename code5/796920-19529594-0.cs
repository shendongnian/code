    private static string FormatFilename(string pattern, DateTime dt)
    {
        Match match = Regex.Match(pattern, @"\{(.*)\}");
        if (!match.Success) return pattern;
        string format = match.Result("$1").Replace("m", "M");
        string date = dt.ToString(format, CultureInfo.InvariantCulture);
        return pattern.Remove(match.Index, match.Length).Insert(match.Index, date);
    }
