    public static List<string> GetValidUrlsFromCSS(string cssStr)
    {
        //Enter properties that can validly contain a URL here (in lowercase):
        List<string> validProperties = new List<string>(new string[] { "background", "background-image" });
    
        List<string> validUrls = new List<string>();
        //We'll use your regex for extracting the valid URLs
        var reUrls = new Regex(@"(?nx)
            url \s* \( \s*
                (
                    (?! ['""] )
                    (?<Url> [^\)]+ )
                    (?<! ['""] )
                    |
                    (?<Quote> ['""] )
                    (?<Url> .+? )
                    \k<Quote>
                )
            \s* \)");
        //First, remove all the comments
        cssStr = Regex.Replace(cssStr, "\\/\\*.*?\\*\\/", String.Empty);
        //Next remove all the the property groups with no selector
        string oldStr;
        do
        {
            oldStr = cssStr;
            cssStr = Regex.Replace(cssStr, "(^|{|})(\\s*{[^}]*})", "$1");
        } while (cssStr != oldStr);
        //Get properties
        var matches = Regex.Matches(cssStr, "({|;)([^:{;]+:[^;}]+)(;|})");
        foreach (Match match in matches)
        {
            string matchVal = match.Groups[2].Value;
            string[] matchArr = matchVal.Split(':');
            if (validProperties.Contains(matchArr[0].Trim().ToLower()))
            {
                //Since this is a valid property, extract the URL (if there is one)
                MatchCollection validUrlCollection = reUrls.Matches(matchVal);
                if (validUrlCollection.Count > 0)
                {
                    validUrls.Add(validUrlCollection[0].Groups["Url"].Value);
                }
            }
        }
        return validUrls;
    }
