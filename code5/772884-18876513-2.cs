    public List<FileEntry> GetFiles()
    {
        byte[] bytes = File.ReadAllBytes(_filePath);
        if (bytes.Length > 0)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(bytes))
                _files = serializer.Deserialize(memoryStream) as List<FileEntry>;
        }
        return _files;
    }
