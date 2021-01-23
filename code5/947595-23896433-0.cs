    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.Schemas.Add ( .... );  // assumes XSD already available
    settings.ValidationEventHandler += delegate( object sender, ValidationEventArgs e )
    {
         DoSomethingAboutSchemaNoncompliance(e.Message);
    };
    // Get a stream from the XML document for use in schema validation.
    XmlReader reader = XmlReader.Create(xd.Save(new System.IO.MemoryStream()), settings);
