    public static T DeserializeFromFile<T>(string xmlFileName) where T: class
    {
        using (FileStream stream = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(stream) as T;
        }
    }
