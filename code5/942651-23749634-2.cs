    class Outer
    {
        public string Action { get; set; }
        [JsonConverter(typeof(InnerConverter))]
        public Inner Data { get; set; }
    }
