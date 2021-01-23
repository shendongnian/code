    public class Query
    {
        public int count { get; set; }
        public string created { get; set; }
        public string email { get; set; }
        public string lang { get; set; }
        public string queryType { get; set; }
        public int responseCount { get; set; }
        public List<object> results { get; set; }
    }
    
    public class ResponseStatus
    {
        public string description { get; set; }
        public int errorCode { get; set; }
        public string status { get; set; }
    }
    
    public class EmailQueryResult
    {
        public Query query { get; set; }
        public ResponseStatus responseStatus { get; set; }
    }
    
    public class VerifyEmailResult
    {
        public EmailQueryResult EmailQueryResult { get; set; }
        public string Message { get; set; }
        public string ResponseMessage { get; set; }
        public string ResultCode { get; set; }
    }
    
    public class RootObject
    {
        public VerifyEmailResult VerifyEmailResult { get; set; }
    }
