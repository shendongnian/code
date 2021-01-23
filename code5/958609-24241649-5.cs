    public XmlReader ReaderFactory(Stream xml, Stream schema)
    {
        XmlSchemaSet sc = new XmlSchemaSet();
    
        // Add the schema to the collection.
        sc.Add(null, XmlReader.Create(schema));
    
        // Set the validation settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    
        settings.Schemas = sc;
        settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
        
        return XmlReader.Create(xml, settings);
    }
