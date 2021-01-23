    Object value = someobject; //Serializable object
    
    XmlSerializer serializer = new XmlSerializer(value.GetType());
    string xmlString;   // will contain XML string
    StringWriter xmlStringWriter = null;  // String writer;
    XmlWriter xmlWriter = null; // XML writer.
    
    XmlWriterSettings writerSettings = new XmlWriterSettings  //XML writer settings
    {
    	OmitXmlDeclaration = true,
    	NewLineOnAttributes = true
    };
    XmlSerializerNamespaces xmlNamespace = new XmlSerializerNamespaces();
    xmlNamespace.Add(string.Empty, string.Empty);// Remove namespaces of XML declaration.
    try
    {
    	xmlStringWriter = new StringWriter(CultureInfo.CurrentCulture);
    	xmlWriter = XmlWriter.Create(xmlStringWriter, writerSettings);
    	serializer.Serialize(xmlWriter, value, xmlNamespace);
    	xmlString = Convert.ToString(xmlStringWriter);
    }
    finally
    {
    	if (xmlStringWriter != null)
    	{
    		xmlStringWriter.Dispose();
    	}
    }
