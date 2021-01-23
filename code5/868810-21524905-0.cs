    public class Wdetail
    {
        public List<object> noffers { get; set; }
        public int offers_count { get; set; }
        public string name { get; set; }
        public int recentoffers_count { get; set; }
        public string sku { get; set; }
        public string url { get; set; }
        public string listprice_currency { get; set; }
        public string listprice { get; set; }
    }
    
    public class Features
    {
        public string __invalid_name__Product Type - General { get; set; }
        public string __invalid_name__Height (in.) { get; set; }
    }
    
    public class Result
    {
        public List<Wdetail> wdetails { get; set; }
        public string model { get; set; }
        public string weight { get; set; }
        public string price_currency { get; set; }
        public List<string> gtins { get; set; }
        public string mpn { get; set; }
        public string cat_id { get; set; }
        public string height { get; set; }
        public Features features { get; set; }
        public string length { get; set; }
        public List<string> geo { get; set; }
        public string width { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public int updated_at { get; set; }
        public string color { get; set; }
        public string manufacturer { get; set; }
        public int images_total { get; set; }
        public List<string> images { get; set; }
        public string brand { get; set; }
        public int offers_total { get; set; }
    }
    
    public class SData
    {
        public List<Result> results { get; set; }
        public int total_results_count { get; set; }
        public int results_count { get; set; }
        public string code { get; set; }
        public int offset { get; set; }
    }
    
    public class RootObject
    {
        public string returnCode { get; set; }
        public SData SData { get; set; }
    }
