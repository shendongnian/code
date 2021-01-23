    private static string Splitter(string str1)
    {
        if (string.IsNullOrWhiteSpace(str1)) return str1;
        var matches = Regex.Matches(str1, @"[\r\n]+");
    
        if (matches.Count == 0)
           return str1;
        else
        {
           var count = matches.Count / 2;
           var pos = matches[count].Index;
           return str1.Substring(pos);
        }
    }
    // Input: "111\n2222\n3333"
    // Output: "\n3333"
