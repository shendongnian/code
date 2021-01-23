    class KvpConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KeyValuePair<string, object>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var kvp = (KeyValuePair<string, object>)value;
            writer.WriteStartObject();
            writer.WritePropertyName(kvp.Key);
            serializer.Serialize(writer, kvp.Value);
            writer.WriteEndObject();
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
