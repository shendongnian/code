    public class Request
    {
        public Int64 transactionId { get; set; }
        public string uri { get; set; }
        public int terminalId { get; set; }
        public string action { get; set; }
        public string amountBase { get; set; }
        public int amountTotal { get; set; }
        public string status { get; set; }
        public DateTime created { get; set; }
        public DateTime lastModified { get; set; }
        public Response response { get; set; }
        public Settlement settlement { get; set; }
        public Vault vault { get; set; }
    }
    public class Response
    {
        public bool approved { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Processor processor { get; set; }
    }
    public class Processor
    {
        public bool authorized { get; set; }
        public string approvedCode { get; set; }
        public AVS avs { get; set; }
    }
    public class AVS
    {
        public string status { get; set; }
    }
    public class Settlement
    {
        public bool settled { get; set; }
    }
    public class Vault
    {
        public string type { get; set; }
        public string accountType { get; set; }
        public string lastFour { get; set; }
    }
