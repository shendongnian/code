    public object DeserializeObject(string xml, Type type)
    {
       var xs = new XmlSerializer(type);
       var stringReader = new StringReader(xml);
       var obj = xs.Deserialize(stringReader);
       stringReader.Close();
       return obj;
    }
    
    // Usage
    var serializer = new Serializer();
    var response = (Response)serializer.DeserializeObject(
        responseXml, typeof(Response));
