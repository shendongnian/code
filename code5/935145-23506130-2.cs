    void PopulateWith(string rawText)
    {
        string pattern = @"ID: (?<id>\d*) NAME: (?<name>.*)";
        foreach (Match match in Regex.Matches(rawText, pattern))
        {
            int id = int.Parse(match.Groups["id"].Value);
            string name = match.Groups["name"].Value;
            name = String.Join(": ", 
                name.Split(new[]{": "}, StringSplitOptions.None).Skip(1).ToArray());
        }
    }
