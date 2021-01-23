    int i = 0;
    foreach(Match match in Regex.Matches(@"MON-123ABC/456 78#AbCd", @"([A-Z]+|[a-z]+|\d+|[^\da-zA-Z]+)"))
    {
        if (match.Success)
        {
            Console.WriteLine("{0}\t{1}", ++i, match.Groups[0]);
        }
    }
