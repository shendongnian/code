    public static string RemoveInvalidXmlChars(string str)
    {
       
        var sb = new StringBuilder();
        var decodedString = HttpUtility.HtmlDecode(str);
        
        foreach (var c in decodedString)
        {
            if (XmlConvert.IsXmlChar(c))
                sb.Append(c);
        }
        return sb.ToString();
    }
