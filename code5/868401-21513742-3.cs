    public class MinDateToNullConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // This converter handles date values directly
            return (objectType == typeof(DateTime));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // The CanConvert method guarantees the value will be a DateTime
            DateTime date = (DateTime)value;
            if (date == DateTime.MinValue)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(date);
            }
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
