    // erase html tags from a string
    public static string StripHtml(string target)
    {
    //Regular expression for html tags
    Regex StripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase |   RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
    
    return StripHTMLExpression.Replace(target, string.Empty);
    }
