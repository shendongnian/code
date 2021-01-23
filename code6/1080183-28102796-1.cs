    public class Buy
    {
        public string href { get; set; }
        public string title { get; set; }
    }
    public class MoreDetails
    {
        public string href { get; set; }
        public string title { get; set; }
    }
    public class Links
    {
        public Buy buy { get; set; }
        public MoreDetails more_details { get; set; }
    }
    public class RootObject
    {
        public int id_product { get; set; }
        public string description { get; set; }
        public Links _links { get; set; }
    }
