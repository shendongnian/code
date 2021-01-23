    public class EnumTypeConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
                    
            EnumValue[] values = EnumHelpers.GetEnumValues((Type)value);
            
            serializer.Serialize(writer, values);
        }
        
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        
        public override bool CanRead { get { return false; } }
        
        public override bool CanConvert(Type objectType)
        {
            
            return typeof(Type).IsAssignableFrom(objectType);
        }
    }
