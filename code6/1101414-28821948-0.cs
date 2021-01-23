    public class Container
    {
        public int id { set; get; }
        public string name { set; get; }
        public int? value { set; get; } // Null when the property was not present in the JSON.
        public Dictionary<string, Container> containers { get; set; }
    }
