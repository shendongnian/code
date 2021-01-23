    public static void ValidateXmlFile<T>(string file, string xsdPath)
    {
        var assembly = typeof(T).Assembly;
        var assName = assembly.GetName().Name;
        var xsdFullPath = String.Format("{0}.{1}", assName, xsdPath);
        var schema = assembly.GetManifestResourceStream(xsdFullPath);
        if (schema == null)
            throw new Exception(String.Format("{0} could not be validated, the XSD schema {1} not found", file, xsdFullPath));
        var xmlIsValid = true;
        var errorMsg = String.Empty;
        var schemaReader = XmlReader.Create(schema);
        var settings = new XmlReaderSettings();
        settings.Schemas.Add(null, schemaReader);
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += (sender, args) =>
        {
            xmlIsValid = false;
            errorMsg = args.Message;
        };
        using (var stream = new FileStream(file, FileMode.Open))
        {
            var xr = XmlReader.Create(stream, settings);
            while (xr.Read()) { }
            if (!xmlIsValid) throw new Exception(String.Format("XML file {0} is not valid: {1}", file, errorMsg));
        }
    }
