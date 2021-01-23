    string newXml = doc.ToString();   
    A result = null;
    DataContractSerializer serializer = new DataContractSerializer(typeof(A));
    
    using (StringReader backing = new StringReader(newXml))
    {
        using (XmlTextReader reader = new XmlTextReader(backing))
        {
            result = (A) serializer.ReadObject(reader);
        }
    }
