    public class DateFormatConverter : JsonConverter
    {
        private readonly string _dateFormat;
        public DateFormatConverter(string format)
        {
            _dateFormat = format;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(_dateFormat));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact(reader.Value.ToString(), _dateFormat, CultureInfo.InvariantCulture);
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
