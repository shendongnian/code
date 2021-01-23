    public class ResponseObj
    {
        public string claims { get; set; }
        public string auth_token { get; set; }
        public string refresh_token { get; set; }
        public DateTime auth_token_expiration { get; set; }
        public DateTime refresh_token_expiration { get; set; }
        public string token_type { get; set; }
    }
