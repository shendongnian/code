    public static string DoSomething(string Content) {
        if (string.IsNullOrEmpty(Content)) 
            return null;
    
        string pattern = "pattern needed";
    
        if (Regex.Match(Content, pattern).Groups.Count > 1)
            return Content;
        else
            return null;
    }
