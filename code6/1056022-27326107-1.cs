    public static class JsonConvertExtensions
    {
        public static IEnumerable<T> DeserializeEnumerable<T>(string filename)
        {
            using (var stream = new StreamReader(filename))
                foreach (var item in DeserializeEnumerable<T>(stream))
                    yield return item;
        }
        public static IEnumerable<T> DeserializeEnumerable<T>(TextReader textReader)
        {
            using (JsonTextReader reader = new JsonTextReader(textReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        // Load each object from the stream and do something with it
                        JObject obj = JObject.Load(reader);
                        if (obj != null)
                        {
                            T item = obj.ToObject<T>();
                            if (item == null)
                                Debug.WriteLine("unknown item type: " + obj.ToString());
                            else
                                yield return item;
                        }
                    }
                }
            }
        }
    }
