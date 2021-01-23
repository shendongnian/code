    public static class Helpers
    {
        public static T Deserialize<T>(this Stream stream) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
