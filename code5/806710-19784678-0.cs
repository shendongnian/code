    string input = "g.portal.com";
    XmlNode foundNode = null;
    foreach (XmlNode node in xDoc.DocumentElement.ChildNodes)
    {
        string value = node.Attributes["Text"].Value;
        string pattern = Regex.Escape(value)
            .Replace(@"\*", ".*")
            .Replace(@"\?", ".");
        if (Regex.IsMatch(input, "^" + pattern + "$"))
        {
            foundNode = node;
            break;  //remove if you want to continue searching
        }
    }
