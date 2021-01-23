    public class EnumValueConverter : JsonConverter
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
            
            EnumValue result = EnumHelpers.GetEnumValue(value, value.GetType());
            
            serializer.Serialize(writer, result);
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
            
            return objectType.IsEnum;
        }
    }
