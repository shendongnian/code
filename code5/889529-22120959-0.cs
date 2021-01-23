    static JToken DeserializeExcludingNulls(string json)
    {
        using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
        {
            return DeserializeExcludingNulls(reader);
        }
    }
    static JToken DeserializeExcludingNulls(JsonReader reader)
    {
        if (reader.TokenType == JsonToken.None)
        {
            reader.Read();
        }
        if (reader.TokenType == JsonToken.StartArray)
        {
            reader.Read();
            JArray array = new JArray();
            while (reader.TokenType != JsonToken.EndArray)
            {
                JToken token = DeserializeExcludingNulls(reader);
                if (!IsEmpty(token))
                {
                    array.Add(token);
                }
                reader.Read();
            }
            return array;
        }
        
        if (reader.TokenType == JsonToken.StartObject)
        {
            reader.Read();
            JObject obj = new JObject();
            while (reader.TokenType != JsonToken.EndObject)
            {
                string propName = (string)reader.Value;
                reader.Read();
                JToken token = DeserializeExcludingNulls(reader);
                if (!IsEmpty(token))
                {
                    obj.Add(propName, token);
                }
                reader.Read();
            }
            return obj;
        }
        return new JValue(reader.Value);
    }
    static bool IsEmpty(JToken token)
    {
        return (token.Type == JTokenType.Null);
    }
