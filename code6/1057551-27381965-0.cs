    public class UnderlyingTypeConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var result = new ZoneProgramInput();
            
            // Deserialize into a temporary JObject
            JObject obj = serializer.Deserialize<JObject>(reader);
            
            // Populate the ZoneProgramInput object with the contents
            serializer.Populate(obj.CreateReader(), result);
                    
            // Overwrite the "Value" property with the correct value based on the 
            // "Type" property.
            result.Value = 
                obj.GetValue("value", StringComparison.OrdinalIgnoreCase)
                   .ToObject(result.Type, serializer);
            
            return result;
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ZoneProgramInput);
        }
        
        public override bool CanWrite
        {
            get { return false; }
        }
    }
