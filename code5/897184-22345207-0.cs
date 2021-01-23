    public class ItemView 
    {
        public string DisplayName { get; set; }
    
        public decimal Price { get; set; }
    }
    
    public class Item : ItemView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ...etc...
    }
