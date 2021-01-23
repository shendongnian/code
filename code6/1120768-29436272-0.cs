    //Serialize: pass your object to this method to serialize it
    public static void Serialize(object value, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(fStream, value);
        }
    }
    
    //Deserialize: Here is what you are looking for
    public static object Deserialize(string path)
    {
        if (!System.IO.File.Exists(path)) { throw new NotImplementedException(); }
        BinaryFormatter formatter = new BinaryFormatter();
        using (Stream fStream = File.OpenRead(path))
        {
            return formatter.Deserialize(fStream);
        }
    }
