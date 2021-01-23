    string pattern = @"d \w+ \s";
    string input = "Dogs are decidedly good pets.";
    RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
    
    foreach (Match match in Regex.Matches(input, pattern, options))
       Console.WriteLine("'{0}// found at index {1}.", match.Value, match.Index);
    // The example displays the following output: 
    //    'Dogs // found at index 0. 
    //    'decidedly // found at index 9
