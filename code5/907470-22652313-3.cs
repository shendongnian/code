    static public void SerializeXML(RootClass details)
    { 
        XmlSerializer serializer = new XmlSerializer(typeof(RootClass)); 
        using (TextWriter writer = new StreamWriter(@"C:\Xml.xml"))
        {
            serializer.Serialize(writer, details); 
        } 
    }
