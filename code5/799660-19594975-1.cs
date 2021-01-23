        public static T FromJson<T>(this string jsonData, Encoding encoding = null) 
            where T : class
        {
            encoding = encoding ?? Encoding.Default;
            var deserializer = new DataContractJsonSerializer(typeof(T));
            var buffer = encoding.GetBytes(jsonData);
            using (var stream = new MemoryStream(buffer))
            {
                return deserializer.ReadObject(stream) as T;
            }
        }
        public static string ToJson<T>(this T obj, Encoding encoding = null) 
            where T : class
        {
            encoding = encoding ?? Encoding.Default;
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return encoding.GetString(stream.ToArray());
            }
        }
