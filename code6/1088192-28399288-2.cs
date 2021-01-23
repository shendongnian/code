        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        public static T GetObject<T>(string json) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return GetObject<T>(json, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializerSettings settings) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), settings);
            return GetObject<T>(json, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializer serializer)
        {
            using (var stream = GenerateStreamFromString(json))
            {
                return (T)serializer.ReadObject(stream);
            }
        }
    then call it like:
            var streams3 = DataContractJsonSerializerHelper.GetObject<Streams>(test, new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
