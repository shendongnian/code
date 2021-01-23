    string input = "US Canada calling @ 1p/sec (Base Tariff - 11p/sec). Validity : 30 Days.";
    
    // Here we call Regex.Match.
    Regex regex = new Regex(@"(\d){1,2}[p/sec]", RegexOptions.IgnorePatternWhitespace);
    MatchCollection matchCollection = regex.Matches(input);
    //   input.IndexOf("p/sec");
    
    // Here we check the Match instance.
    foreach (Match match in matchCollection)
    {
         Console.WriteLine(match.Groups[0].Value);
    }
