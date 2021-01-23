    public class Credentials
    {
        [JsonProperty("agent")]
        public Agent Agent { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    
    public class Agent
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("version")]
        public int Version { get; set; }
    }
