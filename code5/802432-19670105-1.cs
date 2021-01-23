    class Output
    {
        public string contact_id;
        public string status;
        public int is_test_data;
        public DateTime datesubmitted;
        [JsonProperty("geocountry")]
        public string variable_standard_geocountry; // <--- what should be this name for it to work?
    }
