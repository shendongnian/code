    string s = "value   \r\n    item";     
    string pattern = @"value\s+item";
    if (System.Text.RegularExpressions.Regex.IsMatch(s, pattern)) {
        System.Console.WriteLine(s.IndexOf("item"));
    }
    
