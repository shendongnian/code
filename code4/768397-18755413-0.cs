    public class NestedArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(List<string>))
            {
                var list = (List<string>)value;
                writer.WriteStartArray();
                foreach (var str in list)
                    writer.WriteRawValue(str);
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteValue(value);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                var value = new List<string>();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    value.Add(JObject.Load(reader).ToString());
                    reader.Read();
                }
                return value;
            }
            return serializer.Deserialize(reader);
        }
    }
