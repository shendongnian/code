    XmlReader reader = XmlReader.Create(@"yourxml.xml");
    XmlSchemaSet schemaSet = new XmlSchemaSet();
    XmlSchemaInference schema = new XmlSchemaInference();
    schemaSet = schema.InferSchema(reader);
    foreach (XmlSchema s in schemaSet.Schemas())
    {
        using (var stringWriter = new StringWriter())
        {
            using (var writer = XmlWriter.Create(stringWriter))
            {
                s.Write(writer);
            }
    
            textbox.text = stringWriter.ToString();
        }
    }
