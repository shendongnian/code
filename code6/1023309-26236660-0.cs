    public static void SerializeObject(string filename, MyObject objectToSerialize)
    {
        var stream = File.Open(filename, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Serialize(stream, objectToSerialize);
        stream.Close();                
    }
