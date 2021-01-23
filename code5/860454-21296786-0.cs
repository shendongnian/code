    public class Attributes
    {
        public string type { get; set; }
        public string url { get; set; }
    }
    
    public class RootObject
    {
        public Attributes attributes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    RootObject c = JsonConvert.DeserializeObject<RootObject>(jsonText);
