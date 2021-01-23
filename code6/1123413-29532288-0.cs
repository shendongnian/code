    public string CreateXML<T>(T ClassObject)
    {
        XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
        // Initializes a new instance of the XmlDocument class.          
      //  XmlSerializer xmlSerializer = new XmlSerializer(ClassObject.GetType());
        var  xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        // Creates a stream whose backing store is memory. 
        using (MemoryStream xmlStream = new MemoryStream())
        {
            xmlSerializer.Serialize(xmlStream, ClassObject);
            xmlStream.Position = 0;
            //Loads the XML document from the specified string.
            xmlDoc.Load(xmlStream);
            return xmlDoc.InnerXml;
        }
       // return null;
    }
