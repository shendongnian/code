    public class Country
    {
        public string Name { get; set; }
        public string A2 { get; set; }
        public int Code { get; set; }
        public int PhonePrefix { get; set; }
    }
    public class Avatars
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
    public class RootObject
    {
        public int CID { get; set; }
        public string Username { get; set; }
        public Country Country { get; set; }
        public string URL { get; set; }
        public int AffiliateID { get; set; }
        public Avatars Avatars { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool AllowCommunity { get; set; }
        public string Token { get; set; }
        public int TokenExpirationInMinutes { get; set; }
        public bool IsKYCRequired { get; set; }
    }
