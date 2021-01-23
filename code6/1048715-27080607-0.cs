    class DeserializedJson
    {
        public string field_1 { get; set; }
        public string field_2 { get; set; }
        public string field_3 { get; set; }
        [JsonProperty]
        private string field_007 
        {
            set { field_3 = value; }
        }
        [JsonProperty]
        private string field_111 
        {
            set { field_1 = value; }
        }
    }
