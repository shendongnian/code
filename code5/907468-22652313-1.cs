    static public void Serialize(RootClass details)
    { 
        XmlSerializer serializer = new XmlSerializer(typeof(RootClass)); 
        using (TextWriter writer = new StreamWriter(@"C:\Xml.xml"))
        {
            serializer.Serialize(writer, details); 
        } 
    }
