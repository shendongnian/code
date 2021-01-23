    public string EscapeCurlyBraces(string value)
    {
        string strRegex = @"(\{\d+\})";
        Regex myRegex = new Regex(strRegex, RegexOptions.None);
        string strReplace = @"{$1}";
        return myRegex.Replace(value, strReplace);
    }
