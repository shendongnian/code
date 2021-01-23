    [DataContract]
    public class Result 
    {
        [DataMember(Name = "@type")] 
        public string @type { get; set; }
        public string barcode { get; set; }
        public string bsp { get; set; }
        public string dpid { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
