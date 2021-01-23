    public static string getBetween(string input, string start, string end)
    {
        var match = Regex.Match(input, String.Format("{0}(.*?){1}", 
                                Regex.Escape(start), Regex.Escape(end)));
        if (match.Success)
            return match.Groups[1].Value;
        return null;
    }
