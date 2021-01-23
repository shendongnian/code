    public class BsonDocumentConverter : JsonConverter
    {
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            var settings = new JsonWriterSettings()
            {
                OutputMode = JsonOutputMode.Strict
            };
            writer.WriteRawValue(value.ToJson(settings));
        }
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Why would I want to deserialize?");
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BsonDocument);
        }
    }
