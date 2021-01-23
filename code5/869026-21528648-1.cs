    XmlDocument doc = new XmlDocument.Load(filename);
    foreach (XmlNode node in doc.ChildNodes)
    {
        if (node.ElementName == "metroStyleManager")
        {
            foreach (XmlNode subNode in node.ChildNodes)
            {
                string key = subNode.LocalName; // Style, Theme, etc.
                string value = subNode.Value; // Blue, Dark, etc.
            }
        }
        else
        {
            ...
        }
    }
