    public class Item
    {
        public int ID { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    
        public virtual List<Item> Recipe { get; set; }
    }
