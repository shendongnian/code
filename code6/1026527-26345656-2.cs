        public class BarConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Bar);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var bar = value as Bar;
                serializer.Serialize(writer, bar.Name);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                  // Note: if you need to read to, you'll need to implement that here too
                  // otherwise just throw a NotImplementException and override `CanRead` to return false
                  throw new NotImplementedException();
            }
        }
