    public string Test2(string text)
    {
        foreach (Match m in Regex.Matches(text, @"(\d+)\s*v\s*(\d+)"))
        {
            text = text.Replace(match.Groups[0].Value,
                                teams.FirstOrDefault(t => t.Id == m.Groups[1].Value)
                                     .Name +
                                " v " +
                                teams.FirstOrDefault(t => t.Id == m.Groups[2].Value)
                                     .Name);
        }
        return text;
    }
