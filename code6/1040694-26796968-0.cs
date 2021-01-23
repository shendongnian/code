    public class JsonUserContext
    {
        public string AccountNo { get; set; }
        public string AuthValue { get; set; }
    }
    public class UserContext
    {
        public string AccountNo { get; set; }
        public Auth AuthValue { get; set; }
    }
    
    public class Auth
    {
        public string TopUpMobileNumber { get; set; }
        public string VoucherAmount { get; set; }
    }
    ...
    var jsonUserContext = JsonConvert.DeserializeObject<JsonUserContext>(json);
    var authJson = jsonUserContext.AuthValue;
    var userContext = new UserContext {
        AccountNo = jsonUserContext.AccountNo,
        AuthValue = JsonConvert.DeserializeObject<JsonUserContext>(authJson);
    };
