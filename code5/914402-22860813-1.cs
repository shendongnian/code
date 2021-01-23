    public class CustomDateTimeFormatConverter : DateTimeConverterBase
    {
        private readonly string dataFormatString;
        public CustomDateTimeFormatConverter(string dataFormatString)
        {
            this.dataFormatString = dataFormatString;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(dataFormatString));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (DateTime).IsAssignableFrom(objectType);
        }
    }
