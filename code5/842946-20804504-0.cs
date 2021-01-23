    string pattern = "...";
    string result = Regex.Replace(line, pattern, m =>
    {
        int digits = 0;
        string comment = m.Groups[4].Value; // $4
        
        int.TryParse(m.Groups[3].Value, out digits); // $3
    
        return string.Format("{0} {1}({2})  // {3}", 
            m.Groups[1].Value, m.Groups[2].Value, digits, comment);
    }, RegexOptions.IgnoreCase);
