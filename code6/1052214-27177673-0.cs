    public void Save<T>(T file, String path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StreamWriter writer = new StreamWriter(path))
        {
            serializer.Serialize(writer, file);
        }
    }
