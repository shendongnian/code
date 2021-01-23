    public string Test3(string text)
    {
        return Regex.Replace(text,
                             @"((?<team>\d+)(?=\s*v))|((?<=v\s*)(?<team>\d+))",
                             new MatchEvaluator(
                                 m => teams.FirstOrDefault(
                                     t => t.Id == m.Groups["team"].Value
                                 ).Name
                             ));
    }
