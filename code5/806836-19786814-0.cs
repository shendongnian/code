    public class Hjeke
    {
        public string id { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }
        public string type { get; set; }
    }
    
    public class Second
    {
        public string id { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }
        public string type { get; set; }
    }
    
    public class Details
    {
        public List<Hjeke> hjeke { get; set; }
        public List<Second> Second { get; set; }
    }
    
    public class Students
    {
        public List<Details> details { get; set; }
    }
    
    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Students> students { get; set; }
    }
