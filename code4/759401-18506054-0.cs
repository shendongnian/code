    public class RequestObj
    {
        public string Method { get; set; }
        public string ResponseCode { get; set; }
        public string HomeBannerURL { get; set; }
        public IList<Account> ResAccount { get; set; }
    }
    public class Account
    {
        public string shopper_uid { get; set; }
        public string customer_name { get; set; }
        public string first_name { get; set; }
    }
