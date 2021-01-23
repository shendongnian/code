    public class State
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string text { get; set; }
    }
    public class Location
    {
        public List<State> states { get; set; }
        public List<City> cities { get; set; }
        public List<object> zipCodes { get; set; }
    }
