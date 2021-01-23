    string input = "This is my text";
    string pattern = "tex.";// Added Regx special charactor
    string replacement = string.Format("<strong>{0}</strong>", "$0");
    
    var result = Regex.Replace(input, Regex.Escape(pattern), replacement, RegexOptions.IgnoreCase);
