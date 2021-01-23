    XmlReaderSettings settings = new XmlReaderSettings()
    {
        CheckCharacters = false,
        ConformanceLevel = ConformanceLevel.Document,
        DtdProcessing = DtdProcessing.Ignore,
        IgnoreComments = true,
        IgnoreProcessingInstructions = true,
        IgnoreWhitespace = true,
        ValidationType = ValidationType.None
    };
    using (XmlExtendableReader xmlreader = new XmlExtendableReader(reader, settings, true))
        _entities = ((Orders)_serializer.Deserialize(xmlreader)).Order;
