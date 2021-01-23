    string pattern = @"
    ^                            # Start at beginning of line so no mid number matches erroneously found
       (
           2(04|[23]6|49|[58]0)  # 2 series only match 204, 226, 236, 249, 250, 280
         |                       # Or it is not 2, then match:
           3(06|43|65)           # 3 series only match 306, 343, 365
        )
    $                            # Further Anchor it to the end of the string to keep it to 3 numbers";
    
    // RegexOptions.IgnorePatternWhitespace allows us to put the pattern over multiple lines and comment it. Does not
    //     affect regex parsing/processing.
    
    var results = Enumerable.Range(0, 2000) // Test to 2000 so we don't get any non 3 digit matches.
                            .Select(num => num.ToString().PadLeft(3, '0'))
                            .Where (num => Regex.IsMatch(num, pattern, RegexOptions.IgnorePatternWhitespace))
                            .ToArray();
    
    Console.WriteLine ("These results found {0}", string.Join(", ", results));
    
    // These results found 204, 226, 236, 249, 250, 280, 306, 343, 365
