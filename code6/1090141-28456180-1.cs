    public sealed class Data
    {
        [JsonConverter(typeof(DictionaryConverter))]
        public IDictionary<string, string> Dict { get; set; }
    }
