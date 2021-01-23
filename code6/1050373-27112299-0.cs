    public class Addons
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class Conditions
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class Conversions
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class ListPrices
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class MutualExclusion
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class Prerequisites
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class Product
    {
        public string href { get; set; }
        public string method { get; set; }
    }
    
    public class Links
    {
        public Addons addons { get; set; }
        public Conditions conditions { get; set; }
        public Conversions conversions { get; set; }
        public ListPrices list_prices { get; set; }
        public MutualExclusion mutual_exclusion { get; set; }
        public Prerequisites prerequisites { get; set; }
        public Product product { get; set; }
    }
    
    public class RootObject
    {
        public string dummy { get; set; }
        public Links links { get; set; }
    }
