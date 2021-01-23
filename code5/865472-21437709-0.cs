    public class PropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) return;
            var serialized = (Serialized)value;
            writer.WriteStartObject();
            writer.WritePropertyName("ref");
            writer.WriteValue(serialized.A);
            writer.WriteEndObject();
        }
    }
