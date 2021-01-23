    var xmlDoc = new XmlDocument();
    var xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false };
    using (var stringReader = new StringReader(xml)) {
        using (var xmlReader = XmlReader.Create(stringReader, xmlReaderSettings)) {
            xmlDoc.Load(xmlReader);
        }
    }
