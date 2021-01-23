    class UtcDateTimeOffsetConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTimeOffset)
            {
                var date = (DateTimeOffset)value;
                value = date.UtcDateTime;
            }
            base.WriteJson(writer, value, serializer);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object value = base.ReadJson(reader, objectType, existingValue, serializer);
            if (value is DateTimeOffset)
            {
                var date = (DateTimeOffset)value;
                value = date.ToLocalTime();
            }
            return value;
        }
    }
