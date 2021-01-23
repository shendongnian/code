    public class Loffer
    {
        public string id { get; set; }
        public string price { get; set; }
        public string seller { get; set; }
    }
    
    public class Sdetail
    {
        public List<Loffer> loffers { get; set; }
        public int O_count { get; set; }
        public string name { get; set; }
        public int r_count { get; set; }
        public string sku { get; set; }
        public string url { get; set; }
        public int? offers_count { get; set; }
        public int? recentoffers_count { get; set; }
    }
    
    public class Features
    {
        public string __invalid_name__Wi-Fi Ready { get; set; }
        public string __invalid_name__BD Live { get; set; }
        public string __invalid_name__Coaxial Digital Audio Outputs { get; set; }
        public string __invalid_name__Audio Outputs { get; set; }
    }
    
    public class Result
    {
        public List<Sdetail> sdetails { get; set; }
        public string model { get; set; }
        public string weight { get; set; }
        public string price_currency { get; set; }
        public List<string> gtins { get; set; }
        public string mpn { get; set; }
        public string amam3_help { get; set; }
        public string cat_id { get; set; }
        public string height { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public Features features { get; set; }
        public string length { get; set; }
        public int created_at { get; set; }
        public List<string> geo { get; set; }
        public string width { get; set; }
        public string upc { get; set; }
        public string ean { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public int updated_at { get; set; }
        public string manufacturer { get; set; }
        public int images_total { get; set; }
        public List<string> images { get; set; }
        public string brand { get; set; }
        public string aam3_id { get; set; }
        public int offers_total { get; set; }
    }
    
    public class SPData
    {
        public List<Result> result { get; set; }
        public int total_results_count { get; set; }
        public int results_count { get; set; }
        public string code { get; set; }
        public int offset { get; set; }
    }
    
    public class RootObject
    {
        public string returnCode { get; set; }
        public SPData SPData { get; set; }
    } 
