    static Entity Deserialize(string fileName)
    {
        Entity data = null;
     
        using (FileStream stream = new FileStream(fileName, FileMode.Open))
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                data = IntermediateSerializer.Deserialize<Entity>(reader, null);
            }
        } 
    
        return data;
    }
