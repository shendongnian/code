    public T Deserialize<T>(string xml)
    {
       using( var stream = new MemoryStream(Encoding.Unicode.GetBytes(xml)) )
       {
           var serializer = new DataContractSerializer(typeof (T));
           T theObject = (T)serializer.ReadObject(stream);
           return theObject;
        }
    }
