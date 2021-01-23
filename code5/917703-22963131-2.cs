    private XDocument GetXmlDocument(String physicalPath)
        {
            XDocument xmlDocument;
            var xmlStream = new System.IO.StreamReader(physicalPath);
            try
            {
                xmlDocument = XDocument.Load(xmlStream, LoadOptions.SetLineInfo);
            }
            catch (XmlException)
            {
                //_log.Warn("Trying to clean document for HexaDecimal", xmlException);
                xmlDocument = XmlSanitizingStream.TryToCleanXMLBeforeParsing(physicalPath);
            }
    
            return xmlDocument;
        }
