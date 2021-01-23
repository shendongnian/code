    var root = JsonConvert.DeserializeObject<RootObj>(json, new DateTimeConverter());
 
    class DateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new DateTime(1970,1,1).Add(TimeSpan.FromTicks(long.Parse((string)reader.Value)));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
