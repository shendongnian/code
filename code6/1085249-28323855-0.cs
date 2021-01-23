    var readerSettings = new XmlReaderSettings() { CheckCharacters = false, ConformanceLevel = ConformanceLevel.Document };
    using (var inputReader = XmlTextReader.Create(xml, readerSettings, new XmlParserContext(null, null, "en", XmlSpace.Default)))
    {
        XsltArgumentList arglist = new XsltArgumentList();
        var xslt = GetXSLT();
        
        var writerSettings = xslt.OutputSettings.Clone();
        writerSettings.CheckCharacters = false;
        using (var outputWriter = XmlWriter.Create(outputStream, writerSettings))
        {
            xslt.Transform(inputReader, arglist, outputWriter);
        }
    }
