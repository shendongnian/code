        public class InnerSerializer : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(inner);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var inner = value as inner;
                writer.WriteStartObject();
                writer.WritePropertyName("baz");
                writer.WriteValue(inner.baz);
                writer.WriteEndObject();
            }
        }
