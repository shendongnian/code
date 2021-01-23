    public class Order
    {
        public string OrderNumber { get; set; }
        public List<Item> Items { get; set; }
    }
    
    public class Item
    {
        public string Name { get; set; }
    }
