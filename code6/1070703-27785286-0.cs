    public  class User
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("fname")]
        public string FirstName { get; set; }
         
        [JsonProperty("age")]
         public string Age { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
