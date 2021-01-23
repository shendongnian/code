    private static string PatternFromStringFormat(string template)
    {
        // replaces only elements like {0}
        string firstPass = Regex.Replace(template, @"\{[0-9]+\}", "(.*?)");
        // replaces elements like {0:000} using a custom matcher
        string secondPass = Regex.Replace(firstPass, @"\{[0-9]+\:(?<len>[0-9]+)\}",
            (match) =>
            {
                var len = match.Groups["len"].Value.Length;
                return "(.{" + len + "*})";
            });
        return "^" + secondPass + "$";
    }
    private static List<string> ReverseStringFormat(string template, string str)
    {
        string pattern = PatternFromStringFormat(template);
        Regex r = new Regex(pattern);
        Match m = r.Match(str);
        List<string> ret = new List<string>();
        for (int i = 1; i < m.Groups.Count; i++)
            ret.Add(m.Groups[i].Value);
        return ret;
    }
