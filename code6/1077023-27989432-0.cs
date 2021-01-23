    [JsonConverter(typeof(Serializer))]
    public class JobResults : CouchDocument, ICanJson
    {
        [JsonProperty("update-datetime")]
        public DateTime UpdateDateTime = new DateTime(1, 1, 1, 0, 0, 0);
        [JsonProperty("job-ids")]
        public JArray JobIDs = new JArray();
        ...
    }
    public class Serializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ...
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ...
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(JobResults).IsAssignableFrom(objectType);
        }
    }
