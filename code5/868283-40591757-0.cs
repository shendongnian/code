    public Dictionary<int, string> GetLineNumber()
    {
        Dictionary<int, string> attrByLineNumber = new Dictionary<int, string>();
        MemoryStream xmlStream = new MemoryStream();
        _xmlDoc.Save(xmlStream);
        xmlStream.Position = 0;
        XPathDocument pathDocument = new XPathDocument(xmlStream);
        foreach (XPathNavigator element in pathDocument.CreateNavigator().Select("//*"))
        {
            if (element.Name.Equals("Textbox"))
            {
                attrByLineNumber.Add(((IXmlLineInfo)element).LineNumber, element.GetAttribute("Name", ""));
            }
        }
        return attrByLineNumber;
    }
