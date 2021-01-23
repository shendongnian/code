    public static object LoadObject()
    {
        if (File.Exists("D://my.bin"))
        {
            FileStream stream = File.OpenRead("D://my.bin");
            BinaryFormatter formatter = new BinaryFormatter();
    
            Dictionary<int, Question> deserializedObject = (Dictionary<int, Question>)formatter.Deserialize(stream);
            stream.Close();
            return deserializedObject;
        }
        else
            throw FileNotFoundException("There is no file named", "D:\\my.bin");
    }
