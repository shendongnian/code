    public class ApiLoginResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
