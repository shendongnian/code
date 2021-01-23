    public static object DeserializePreservingReferences(string json)
    {
        using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
        {
            return DeserializePreservingReferences(reader, 
                       new Dictionary<string, Dictionary<string, object>>());
        }
    }
    private static object DeserializePreservingReferences(JsonTextReader reader,
                             Dictionary<string, Dictionary<string, object>> lookup)
    {
        if (reader.TokenType == JsonToken.None)
        {
            reader.Read();
        }
        if (reader.TokenType == JsonToken.StartArray)
        {
            List<object> list = new List<object>();
            while (reader.Read() && reader.TokenType != JsonToken.EndArray)
            {
                list.Add(DeserializePreservingReferences(reader, lookup));
            }
            return list;
        }
        if (reader.TokenType == JsonToken.StartObject)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                string propName = (string)reader.Value;
                reader.Read();
                if (propName == "$ref")
                {
                    dict = lookup[reader.Value.ToString()];
                }
                else if (propName == "$id")
                {
                    lookup[reader.Value.ToString()] = dict;
                }
                else
                {
                    dict.Add(propName, DeserializePreservingReferences(reader, lookup));
                }
            }
            return dict;
        }
        return new JValue(reader.Value).Value;
    }
