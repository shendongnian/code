    public static class DataContractJsonSerializerHelper
    {
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        public static string GetJson<T>(T obj, DataContractJsonSerializer serializer)
        {
            using (var memory = new MemoryStream())
            {
                serializer.WriteObject(memory, obj);
                memory.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static string GetJson<T>(T obj) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return GetJson(obj, serializer);
        }
        public static string GetJson<T>(T obj) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return GetJson(obj, serializer);
        }
        public static T GetObject<T>(string json) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return GetObject<T>(json, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializer serializer)
        {
            T obj = default(T);
            using (var stream = GenerateStreamFromString(json))
            {
                obj = (T)serializer.ReadObject(stream);
            }
            return obj;
        }
    }
