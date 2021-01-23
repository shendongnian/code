        public class Config
        {
            public String Name { get; set; }
            [JsonIgnore]
            public Dictionary<string, string> Configuation { get; set; }
            [JsonExtensionData]
            private Dictionary<string, JToken> _configuration;
            [OnDeserialized]
            private void Deserialized (StreamingContext context)
            {
                Configuation = _configuration.ToDictionary(i => i.Key, i => (string)i.Value);
            }
        }
