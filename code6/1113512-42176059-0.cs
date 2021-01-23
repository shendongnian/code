    public class UserInfo
    {
        public string UserName { get; set; }
    
        [JsonConverter(typeof(EncryptingJsonConverter), "My-Sup3r-Secr3t-Key")]
        public string UserPassword { get; set; }
    
        public string FavoriteColor { get; set; }
    
        [JsonConverter(typeof(EncryptingJsonConverter), "My-Sup3r-Secr3t-Key")]
        public string CreditCardNumber { get; set; }
    }
