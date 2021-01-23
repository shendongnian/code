    public static class JsonExtensions
    {
        public static byte[] SerializeToByteArray<T>(T data, JsonSerializerSettings settings)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new BsonWriter(stream))
                {
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(writer, data);
                }
                return stream.ToArray();
            }
        }
        public static T DeserializeFromByteArray<T>(byte[] serializedData, JsonSerializerSettings settings)
        {
            using (var stream = new MemoryStream(serializedData))
            {
                using (var reader = new BsonReader(stream))
                {
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    return (T)serializer.Deserialize<T>(reader);
                }
            }
        }
    }
    public static class TestClass
    {
        public static void Test()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>(1);
            List<FavoriteLevel> levels = new List<FavoriteLevel>(1);
            levels.Add(new FavoriteLevel("123", 0));
            dict.Add("123", levels);
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.All;
            byte[] data = JsonExtensions.SerializeToByteArray(dict, settings);
            Dictionary<string, object> incomingDict = JsonExtensions.DeserializeFromByteArray<Dictionary<string, object>>(data, settings);
            object listBack = incomingDict["123"];
            Debug.Assert(listBack.GetType() == levels.GetType()); // No assert.
        }
    }
