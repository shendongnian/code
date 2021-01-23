    public static class JsonUtils
    {
        class JsonSerializer<T>
        {
            static DataContractJsonSerializer xs = new DataContractJsonSerializer(typeof(T));
            public static object DeserializeObject(string serializedData, Encoding encoding)
            {
                byte[] data = encoding.GetBytes(serializedData);
                MemoryStream sr = new MemoryStream(data);
                return xs.ReadObject(sr);
            }
            public static string SerializeObject(T obj, Encoding encoding)
            {
                MemoryStream ms = new MemoryStream();
                xs.WriteObject(ms, obj);
                byte[] data = ms.ToArray();
                return encoding.GetString(data);
            }
        }
        public static T DeserializeObject<T>(this string serializedData)
        {
            return (T)JsonSerializer<T>.DeserializeObject(serializedData, Encoding.Default);
        }
        public static string SerializeObject<T>(this T obj)
        {
            return JsonSerializer<T>.SerializeObject(obj, Encoding.Default);
        }
    }
