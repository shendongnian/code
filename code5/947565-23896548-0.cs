    private static void RecurseXmlDocument(XmlNode root)
    {
        if (root is XmlElement)
        {
            Console.Write("\n" + root.Name + ": ");
            if (root.HasChildNodes) RecurseXmlDocument(root.FirstChild);
            if (root.NextSibling != null) RecurseXmlDocument(root.NextSibling);
        }
        else if (root is XmlText)
        {
            Console.Write(((XmlText)root).Value);
        }
        else if (root is XmlComment)
        {
            Console.Write(root.Value);
            if (root.HasChildNodes) RecurseXmlDocument(root.FirstChild);
            if (root.NextSibling != null) RecurseXmlDocument(root.NextSibling);
        }
    }
