    class DeserializedJson
    {
        public string field_1 { get; set; }
        public string field_2 { get; set; }
        public string field_3 { get; set; }
    }
    class DeserializedJsonAPI1 : DeserializedJson
    {
        [JsonProperty]
        private string field_007
        {
            set { field_2 = value; }
        }
    }
    class DeserializedJsonAPI2 : DeserializedJson
    {
        [JsonProperty]
        private string field_007
        {
            set { field_3 = value; }
        }
    }
