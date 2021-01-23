    public class MyResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
    
    MyResponse response = new MyResponse();
    // Fill in properties
    string json = JsonConvert.SerializeObject(response);
