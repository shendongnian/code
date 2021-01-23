    public IList<T> BinaryFileDeSerialize<T>(string filePath) where T: Class
    {
        var list = new List<T>();
       
        if (!File.Exists(filePath))
           throw new FileNotFoundException("The file" + " was not found. ", filePath);
        using(var fileStream = new FileStream(filePath, FileMode.Open))
        {
              BinaryFormatter b = new BinaryFormatter(); obj = b.Deserialize(fileStream);
              while(fileStream.Position < fileStream.Length)
                 list.Add(b.Deserialize(fileStream));
        }                     
        return list;
    }
