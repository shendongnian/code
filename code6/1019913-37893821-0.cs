    public class ContextBaseSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ContextBase).GetTypeInfo().IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contextBase = value as ContextBase;
            var valueToken = JToken.FromObject(value, new ForcedObjectSerializer());
            if (contextBase.Properties != null)
            {
                var propertiesToken = JToken.FromObject(contextBase.Properties);
                foreach (var property in propertiesToken.Children<JProperty>())
                {
                    valueToken[property.Name] = property.Value;
                }
            }
            valueToken.WriteTo(writer);
        }
    }
    
