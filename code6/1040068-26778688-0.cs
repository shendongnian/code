    public class RootObject
    {
        public Dictionary<string, Cars> details { get; set; }
    }
    public class Cars
    {
        public List<Car> Car { get; set; }
    }
    public class Car
    {
        public string id { get; set; }
        public string text { get; set; }
        public string sub_text { get; set; }
        public string category_id { get; set; }
    }
