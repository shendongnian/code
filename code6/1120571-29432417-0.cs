    // Response model
    public class DataResponse
    {
        [JsonProperty("data")]
        public string Data { get; set; }
    
        [JsonProperty("total_user")]
        public int TotalUsersCount { get; set; }
    
        [JsonProperty("unverified_count")]
        public int UnverifiedCount { get; set; }
    
        [JsonProperty("verified_count")]
        public int VerifiedCount { get; set; }
    
        [JsonProperty("deactivate_count")]
        public int DeactivateCount { get; set; }
    
        [JsonProperty("verified")]
        public List<UserInfo> VerifiedUsers { get; set; }
    
        [JsonProperty("unverified")]
        public List<UserInfo> UnverifiedUsers { get; set; }
    
        [JsonProperty("deactivate")]
        public List<UserInfo> DeactivateUsers { get; set; }
    }
    
    // User model
    public class UserInfo
    {
        [JsonProperty("user_id")]
        public int Id { get; set; }
    
        [JsonProperty("user_name")]
        public string Name { get; set; }
    
        [JsonProperty("money")]
        public double? Money { get; set; }
    }
