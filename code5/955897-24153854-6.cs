    public class RootObject
    {
        public List<Item> items { get; set; }
        public string seconds_ago { get; set; }
    }
    public class Item
    {
        public string id { get; set; }
        public string quantity { get; set; }
        public string bundle { get; set; }
    }
    
    RootObject deserializedObject = JsonConvert.DeserializeObject<RootObject>(json);
