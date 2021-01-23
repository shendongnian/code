    public class ClassAJsonConverter : JsonConverter
    {
        private IContractResolver exclusionResolver = 
            new JsonConverterExclusionResolver<ClassAJsonConverter>();
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ClassA);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonSerializer innerSerializer = new JsonSerializer();
            innerSerializer.ContractResolver = exclusionResolver;
            // (copy other settings from the outer serializer if needed)
            var o = JObject.FromObject(value, innerSerializer);
            // ...do your custom stuff here...
            
            o.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
