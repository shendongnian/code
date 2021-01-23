    var position = 0;
    var tagRegex = new TagRegex();
    var endTagRegex = new EndTagRegex();
    
    while (position < html.length)
    {
        var match = tagRegex.Match(html, position);
    
        if (match.Success)
        {
            var tagName = match.Groups["tagname"].Value;
            if (tagName == "a") 
            { ... }
        }
        else if (endTagRegex.match(html, position).Success)
        {
            var tagName = match.Groups["tagname"].Value;
            if (tagName == "a") 
            { ... }
        }
        position++;
    }
