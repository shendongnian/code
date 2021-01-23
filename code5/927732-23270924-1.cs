    public static string DoSomething(string Content)
    {
        if (string.IsNullOrEmpty(Content))
            return null;
    
        string pattern = @"(?is)\s*\$\s*(.*)";
    
        if (Regex.IsMatch(Content, pattern))
            return Content;
        else
            return null;
    }
