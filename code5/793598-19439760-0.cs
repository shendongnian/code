    class BoolStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (typeof(string) == objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            string str = token.Value<string>();
            if (string.Equals("true", str, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("false", str, StringComparison.OrdinalIgnoreCase))
            {
                str = str.ToLower();
            }
            return str;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
