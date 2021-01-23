    List<string> inputs = new List<string>() { "AUSTIN,ORL2,ORL6", "CHA,INDY" };
    List<string> results = new List<string>();
    foreach (string input in inputs)
    {
        List<string> resultComponents = new List<string>();
        foreach (Match match in Regex.Matches(input, "([A-Z0-9]+(?=,)?)"))
        {
            if (match.Success) resultComponents.Add(string.Format("<a href='details.aspx?location={0}'>{0}</a>", match.Value));
        }
        results.Add(string.Join(", ", resultComponents));
    }
