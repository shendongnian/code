    public class Ndetail
    {
        public List<object> laoffers { get; set; }
        public int offers_count { get; set; }
        public string sku { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public int? o_count { get; set; }
        public int? recentoffers_count { get; set; }
    }
    
    public class Features
    {
        public string Condition { get; set; }
        public string __invalid_name__RAM - Memory { get; set; }
        public string __invalid_name__Rear-facing Camera - Camera { get; set; }
    }
    
    public class Result
    {
        public List<Ndetail> ndetails { get; set; }
        public string model { get; set; }
        public string weight { get; set; }
        public string price_currency { get; set; }
        public List<string> gtins { get; set; }
        public string cat_id { get; set; }
        public Features features { get; set; }
        public string length { get; set; }
        public int created_at { get; set; }
        public string variation_id { get; set; }
        public List<string> geo { get; set; }
        public string width { get; set; }
        public string upc { get; set; }
        public string ean { get; set; }
        public string category { get; set; }
        public string price { get; set; }
        public int updated_at { get; set; }
        public string color { get; set; }
        public string manufacturer { get; set; }
        public int images_total { get; set; }
        public List<string> images { get; set; }
        public string brand { get; set; }
        public string sem3_id { get; set; }
        public int offers_total { get; set; }
    }
    
    public class SpData
    {
        public List<Result> results { get; set; }
        public int total_results_count { get; set; }
        public int results_count { get; set; }
        public string code { get; set; }
        public int offset { get; set; }
    }
    
    public class RootObject
    {
        public string rC { get; set; }
        public SpData SpData { get; set; }
    }
    
    
    DataContractJsonSerializer useful with this class architecture to parse a json string.
    Below is the sample code.
    
     MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(Your json string));
     DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(RootObject));
    RootObject parsedData= dataContractJsonSerializer.ReadObject(memoryStream) as RootObject;
