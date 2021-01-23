    public static XDocument TryToCleanXMLBeforeParsing(String physicalPath)
    {
        string xml;
        Encoding encoding;
        using (var reader = new XmlSanitizingStream(File.OpenRead(physicalPath)))
        {
            xml = reader.ReadToEnd();
            encoding = reader.CurrentEncoding;
        }
        byte[] encodedString;
        if (encoding.Equals(Encoding.UTF8)) encodedString = Encoding.UTF8.GetBytes(xml);
        else if (encoding.Equals(Encoding.UTF32)) encodedString = Encoding.UTF32.GetBytes(xml);
        else encodedString = Encoding.Unicode.GetBytes(xml);
        var ms = new MemoryStream(encodedString);
        ms.Flush();
        ms.Position = 0;
        var settings = new XmlReaderSettings {CheckCharacters = false};
        XmlReader xmlReader = XmlReader.Create(ms, settings);
        var xmlDocument = XDocument.Load(xmlReader);
        ms.Close();
        return xmlDocument;
    }
