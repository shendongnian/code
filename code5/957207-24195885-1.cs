    public class InputJson
    {
        [JsonProperty(PropertyName = "signals")]
        [JsonConverter(typeof(BlobJsonConverter))]
        public string signals { get; set; }
        [JsonProperty(PropertyName = "options")]
        public string options { get; set; }
        [JsonProperty(PropertyName = "fields")]
        public string fields { get; set; }
        [JsonProperty(PropertyName = "lapse")]
        public string lapse { get; set; }
    }
