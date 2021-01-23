    public class Results {
        public bool BoolValue { get; set; }
        public Dictionary<string, Item> Inventory { get; set; }
    }
    public class Item {
        public string id { get; set; }
        public string name { get; set; }
    }
