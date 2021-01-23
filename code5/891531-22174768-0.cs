    //Note the special escape character here for the regex engine not to fail on a found ')'
    string string1 = @"1.1\)The Element is:";
    
    List<string> testStrings = new List<string>();
    testStrings.Add(@"1.1)The Element is:(-) for the sub 1");
    testStrings.Add(@"1.1)The Element is:) for the sub 2");
    testStrings.Add(@"1.1)The Element is:[-] for the sub 3");
                          
    //Create a regular expression string based upon the 'string1' provided above.
    string regularExpression = string.Format(@"(?<base>{0})+(?:[^\\sa-zA-Z0-9]+)", string1);
    Regex regex = new Regex(regularExpression, RegexOptions.Multiline);
    //Will contain the found results
    List<string> subStrings = new List<string>();
    
    foreach (string str in testStrings)
    {
      foreach (Match match in regex.Matches(str))
      {
        if (match.Success)
        {
          subStrings.Add(str.Replace(match.Groups[0].ToString(), string.Empty));
        }
      }
    }
    //Display the found results
    foreach (string str in subStrings)
    {
      Console.WriteLine(str);
    }
