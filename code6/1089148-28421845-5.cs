    public static class DataContractJsonSerializerHelper
    {
        public static T GetObject<T>(string json) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return GetObject<T>(json, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializer serializer)
        {
            using (var stream = GenerateStreamFromString(json))
            {
                var obj = serializer.ReadObject(stream);
                return (T)obj;
            }
        }
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
    }
