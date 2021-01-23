    List<String> list = new List<string>();
    string pattern = @"^[^a-z]+$";
    foreach (string line in query)
    {
        Regex r = new Regex(pattern, RegexOptions.None);
        Match match = r.Match(line);
        if (match.Value != "")
            list.Add(match.Value);
       }
