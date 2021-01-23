    public class CustomField
    {
        public string field { get; set; }
        public string value { get; set; }
    }
    
    public class Data
    {
        public List<CustomField> custom_fields { get; set; }
        public string email { get; set; }
        public string state { get; set; }
    }
    
    public class RootObject
    {
        public Data data { get; set; }
        public string status { get; set; }
    }
