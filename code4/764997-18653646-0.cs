    public class SomeModel
    {
        public LoginAccount[] LoginAccounts { get; set; }
    }
    
    public class LoginAccount
    {
        public string Name { get; set; }
        public string AccountId { get; set; }
        public string BaseUrl { get; set; }
        public string IsDefault { get; set; }
        ...
    }
