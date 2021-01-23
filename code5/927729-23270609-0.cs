    public static string DoSomething(string Content) {
        if (string.IsNullOrEmpty(Content)) 
            return null;
    
        string pattern = @"\s*\$\s*(.*)";
    
        if (Regex.Match(Content, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups.Count > 1)
            return Content;
        else
            return null;
    }
