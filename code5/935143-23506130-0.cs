    void PopulateWith(string rawText)
    {
        string pattern = @"ID: (?<id>\d*) NAME: (?<name>.*)";
        foreach (Match match in Regex.Matches(rawText, pattern))
        {
            int id = int.Parse(match.Groups["id"].Value);
            string name = match.Groups["name"].Value;
            string[] req = name.Split(':');
            name = String.Empty;
            for(int i = 1; i < req.Length; i++)
                name += String.Format("{0}{1} ", req[i], i == req.Length - 1 ? String.Empty : ":");
        }
    }
