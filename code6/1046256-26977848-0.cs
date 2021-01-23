    public class Item {
        public int Key { get; set; }
        public string Name { get; set; }
        public Item Child { get; set; }
    }
    
    List<Item> myList = new List<Item>();
