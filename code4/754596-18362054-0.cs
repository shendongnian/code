    //Convert pattern to regex (I'm assuming this can be done with your "originalText")
    Regex regex = pattern;
    //For each  match, replace the found pattern with the original value + " -"
    foreach (Match m in regex.Matches)
    {
        RegEx.Replace(pattern, m.Groups[0].Value + " -");
    }
