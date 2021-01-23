    /// <summary>
    /// Converts the NameValue-array with object containing name and value to a Dictionary.
    /// </summary>
    internal class JsonNameValueListToDictionaryConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, string> dictionary = existingValue as Dictionary<string, string> ?? new Dictionary<string, string>();
            if (reader.TokenType == JsonToken.StartArray)
            {
                int startDepth = reader.Depth;
                while (reader.Read())
                {
                    if ((reader.Depth == startDepth) && (reader.TokenType == JsonToken.EndArray)) break;
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        KeyValuePair<string, string> kvp = GetKeyValueFromJsonObject(reader, "Name", "Value");
                        dictionary[kvp.Key] = kvp.Value; // always override existing keys
                    }
                    else
                    {
                        throw new NotSupportedException(String.Format("Unexpected JSON token '{0}' while reading special Dictionary", reader.TokenType));
                    }
                }
            }
            return dictionary;
        }
        private KeyValuePair<string, string> GetKeyValueFromJsonObject(JsonReader reader, string propNameKey, string propNameValue)
        {
            string key = null;
            string value = null;
            int startDepth = reader.Depth;
            while (reader.Read())
            {
                if ((reader.TokenType == JsonToken.EndObject) && (reader.Depth == startDepth)) break;
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    string propName = reader.Value as string;
                    if (propName == null) continue;
                    if (propName.Equals(propNameKey, StringComparison.InvariantCulture))
                    {
                        key = reader.ReadAsString();
                    }
                    else if (propName.Equals(propNameValue, StringComparison.InvariantCulture))
                    {
                        value = reader.ReadAsString();
                    }
                }
            }
            return new KeyValuePair<string, string>(key, value);
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType.Equals(typeof(Dictionary<string, string>)));
        }
    }
