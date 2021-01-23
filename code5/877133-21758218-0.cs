    // Note I capitalized Product
    public class Product
    {
        public string status { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string end_date { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public string long_title { get; set; }
    }
    /*
     * Use DataMember to map the keys starting with numbers to an alternative c# compatible name.
     * Unfortunately this requires properties to opt in to the data contract.
     */
    [DataContract]
    public class Merchant
    {
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public List<string> country_whitelist { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public List<string> url_blacklist { get; set; }
        [DataMember]
        public List<string> country_blacklist { get; set; }
        [DataMember]
        public List<string> url_whitelist { get; set; }
        [DataMember]
        public Dictionary<int, Product>  products { get; set; }
        [DataMember]
        public string sub_category { get; set; }
        // This maps the 88x31 key to a c# appropriate name
        [DataMember(Name = "88x31")]
        public string image88x31 { get; set; }
    }
