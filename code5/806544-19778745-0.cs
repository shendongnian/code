    class CustomDateTimeConverter : DateTimeConverterBase
    {
        private const string Format = "dd.MM.yyyy";
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime d = (DateTime)value;
            string s = d.ToString(Format);
            writer.WriteValue(s);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (s == null)
                return null;
            string s = (string)reader.Value;
            return DateTime.ParseExact(s, Format, null);
        }
    }
