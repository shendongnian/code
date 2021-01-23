    public static class JsonConvertExtensions
    {
        public static IEnumerable<T> DeserializeEnumerableFile<T>(string filename)
        {
            using (var stream = new StreamReader(filename))
                foreach (var item in DeserializeEnumerable<T>(stream))
                    yield return item;
        }
        public static IEnumerable<T> DeserializeEnumerableString<T>(string json)
        {
            using (var sr = new StringReader(json))
                foreach (var item in DeserializeEnumerable<T>(sr))
                    yield return item;
        }
        public static IEnumerable<T> DeserializeEnumerable<T>(TextReader textReader)
        {
            var serializer = JsonSerializer.CreateDefault();
            using (JsonTextReader reader = new JsonTextReader(textReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        // Load each object from the stream and do something with it
                        yield return serializer.Deserialize<T>(reader);
                    }
                }
            }
        }
    }
