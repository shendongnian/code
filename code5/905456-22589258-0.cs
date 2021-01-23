    string input = "1|2|3,4,5,6|7,8|9";
    string pattern = @"[,|]+";
    
    // Collect the values
    string[] substrings = Regex.Split(input, pattern);
    // Collect the delimiters
    MatchCollection matches = Regex.Matches(input, pattern);
    
    // Replace anything you like, i.e.
    substrings[3] = "222";
    
    // Rebuild the string
    int i = 0;
    string newString = string.Empty;
    foreach (string substring in substrings)
    {
        newString += string.Concat(substring, matches.Count >= i + 1 ? matches[i++].Value : string.Empty);
    }
