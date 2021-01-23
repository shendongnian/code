    public class StringContentConverter :JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(HttpContent).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader); //There's nothing in here that says "Hello World!".  The string content hides it.
        }
    }
