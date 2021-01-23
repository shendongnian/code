    private Boolean m_success = true;
    private void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        m_success = false;
        Console.WriteLine("\r\n\tValidation error: " + args.Message);
    }
    public void validate(string xmlfile, string ns, string xsdfile)
    {
        m_success = true;
        XmlReaderSettings settings = new XmlReaderSettings();
        XmlSchemaSet sc = new XmlSchemaSet();
        sc.Add(ns, xsdfile);
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas = sc;
        settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        XmlReader reader = XmlReader.Create(xmlfile, settings);
        // Parse the file. 
        while (reader.Read()) ;
        Console.WriteLine("Validation finished. Validation {0}", (m_success == true ? "successful!" : "failed."));
        reader.Close();
    }
