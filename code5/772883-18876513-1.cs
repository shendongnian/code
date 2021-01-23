    public void AddFiles(string[] Files)
    {
        int index = _files.Count;
        foreach (string file in Files)
        {
        {
            _files.Add(new FileEntry());
            _files[index].Name = Path.GetFileNameWithoutExtension(file);
            _files[index].Content = File.ReadAllBytes(file);
            index++;
        }
        byte[] bytes = null;
        BinaryFormatter serializer = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream())
        {
            serializer.Serialize(memoryStream, _files);
            bytes = memoryStream.ToArray();
        }
        File.WriteAllBytes(_filePath, bytes);
    }
