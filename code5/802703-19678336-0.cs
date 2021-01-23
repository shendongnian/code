    ...
    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
    {
       DataContractSerializer serializer = new DataContractSerializer(typeof(List<PiwikDbData>));
    
       List<PiwikDbData>visitlist = serializer.ReadObject(stream);
    }
    ...
