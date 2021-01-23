    public IList<T> BinaryFileDeSerialize<T>(string filePath) where T: class
    {
        var list = new List<T>();
       
        if (!File.Exists(filePath))
           throw new FileNotFoundException("The file" + " was not found. ", filePath);
        using(var fileStream = new FileStream(filePath, FileMode.Open))
        {
              BinaryFormatter b = new BinaryFormatter(); 
              while(fileStream.Position < fileStream.Length)
                 list.Add((T)b.Deserialize(fileStream));
        }                     
        return list;
    }
