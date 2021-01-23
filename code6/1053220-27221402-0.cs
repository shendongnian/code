    class Stuff 
    {
        public int A { get; set; }
        public string B { get; set; }
        [JsonExtensionData]
        public JObject Others { get; set; }
    }
