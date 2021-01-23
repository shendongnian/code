    public void Save(string filePath,List<SiteDetail> data)
    {
        Stream stream= File.Create(filePath);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(stream, data);
        stream.Close();
    }
