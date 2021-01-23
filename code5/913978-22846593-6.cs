    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        private readonly string defaultTimeZoneId;
        public CustomDateTimeConverter(string defaultTimeZoneId)
        {
            this.defaultTimeZoneId = defaultTimeZoneId;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof (DateTimeOffset) && objectType != typeof (DateTimeOffset?))
                return base.ReadJson(reader, objectType, existingValue, serializer);
            var dateText = reader.Value.ToString();
            if (objectType == typeof(DateTimeOffset?) && string.IsNullOrEmpty(dateText))
                return null;
            if (dateText.IndexOfAny(new[] { 'Z', 'z', '+'}) == -1 && dateText.Count(c => c == '-') == 2)
            {
                var dt = DateTime.Parse(dateText);
                var tz = TimeZoneInfo.FindSystemTimeZoneById(this.defaultTimeZoneId);
                var offset = tz.GetUtcOffset(dt);
                return new DateTimeOffset(dt, offset);
            }
            return DateTimeOffset.Parse(dateText);
        }
    }
