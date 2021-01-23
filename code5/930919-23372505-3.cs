    public static class Serialization<T> where T : class   
    {    
        public static T DeserializeFromXmlFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
            using (Stream stream = File.OpenRead(fileName))
            {
                return (T)deserializer.ReadObject(stream);
            }
        }
    }
