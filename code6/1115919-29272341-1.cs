    string input = "This is my text";
    string pattern = Regex.Escape("tex.");// Added Regx special charactor
    string replacement = string.Format("<strong>{0}</strong>", "$0");
    
    var result = Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);
