    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            DateTimeStyles = DateTimeStyles.AdjustToUniversal;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType
               , object existingValue, JsonSerializer serializer)
        {
            var result = base.ReadJson(reader, objectType, existingValue, serializer);
            var dateTime = result as DateTime?;
            if (dateTime.Is() && dateTime.Value.Kind == DateTimeKind.Utc)
            {
                return dateTime.Value.ToLocalTime();
            }
            return result;
        }
