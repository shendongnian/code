    public class CurrentAlarms
    {
        public string Desc { get; set; }
        public string Station { get; set; }
        [JsonConverter(typeof(InvalidDataFormatJsonConverter))]
        public DateTime When { get; set; }
        public CurrentAlarms() { }
        public CurrentAlarms(string desc, string station, DateTime when)
        {
            Desc = desc;
            Station = station;
            When = when;
        }
    }
    class InvalidDataFormatJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // implement in case you're serializing it back
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var dataString = (string) reader.Value;
            DateTime date = parseDataString;             
            return date;
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
