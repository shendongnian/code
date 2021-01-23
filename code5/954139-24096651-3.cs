        public class User
        {
           [JsonProperty(PropertName = username)]
           public string Username { get; set; }
    
           [JsonProperty(PropertName = password)]
           public string Password { get; set; }
        }
