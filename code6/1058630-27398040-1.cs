    public class MyJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
     
            // write your object here based on your custom logic
            writer.WriteRawValue(value);
     
            writer.WriteEndArray();
        }
     
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
     
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
