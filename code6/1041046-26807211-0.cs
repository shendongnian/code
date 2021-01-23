    titles = System.Net.WebUtility.HtmlDecode(titles);
    
    foreach (Match match in Regex.Matches(titles, 
             @"^\s*<title>\s*\""*(.*?)(\""|\(\d{4}\))", RegexOptions.Multiline | RegexOptions.IgnoreCase))
    {
        if (match.Success)
        {
            string name = match.Groups[1].Value;
        }
    }
