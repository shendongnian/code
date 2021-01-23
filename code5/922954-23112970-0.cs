    public static Regex regex = new Regex(
              "\\b[a-zA-Z]{2}\\d{5}\\b",
        RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );
    
    
    
    //// Replace the matched text in the InputText using the replacement pattern
    // string result = regex.Replace(InputText,regexReplace);
    
    //// Split the InputText wherever the regex matches
    // string[] results = regex.Split(InputText);
    
    //// Capture the first Match, if any, in the InputText
    // Match m = regex.Match(InputText);
    
    //// Capture all Matches in the InputText
    // MatchCollection ms = regex.Matches(InputText);
    
    //// Test to see if there is a match in the InputText
    // bool IsMatch = regex.IsMatch(InputText);
    
    //// Get the names of all the named and numbered capture groups
    // string[] GroupNames = regex.GetGroupNames();
    
    //// Get the numbers of all the named and numbered capture groups
    // int[] GroupNumbers = regex.GetGroupNumbers();
