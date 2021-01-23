    public static class JsonExtensions
    {
        public static IEnumerable<JObject> WalkObjects(TextReader textReader)
        {
            using (JsonTextReader reader = new JsonTextReader(textReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        JObject obj = JObject.Load(reader);
                        if (obj != null)
                        {
                            yield return obj;
                        }
                    }
                }
            }
        }
    }
