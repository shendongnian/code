    public class Test
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
    
    public class Item
    {
        public int Id { get; set; }
        public bool Selected { get; set; }
        public string Description { get; set; }
    }
