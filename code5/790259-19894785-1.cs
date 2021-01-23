    public object Deserialize(XmlReader xmlReader, string encodingStyle, XmlDeserializationEvents events)
    {
        // instantiate specific for our class Reader 
        // from dynamically generated assembly
        XmlSerializationReader reader = CreateReader(); 
        reader.Init(xmlReader, events, encodingStyle, tempAssembly); 
        try { 
            //call dynamically generated for out particular type method
            return Deserialize(reader);
        } 
        finally {
            reader.Dispose();
        }
    }
