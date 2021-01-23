    /// <summary>
    /// the regex to match. Uses the Ingore case flag, compiled and single line
    /// </summary>
    readonly static Regex xmlUriRegex = new Regex("^http(s?)://(.*).xml$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
    
    /// <summary>
    /// Checks if the string input is a valid XML uri that starts with an http protocol, ends with .xml and is a valid URI
    /// </summary>
    /// <param name="xmlUri">the uri</param>
    /// <returns></returns>
    public static bool IsValidXMLUri(string xmlUri)
    {
        Uri u = null;
        return Uri.TryCreate(xmlUri, UriKind.Absolute, out u) && xmlUriRegex.IsMatch(xmlUri);
    }
