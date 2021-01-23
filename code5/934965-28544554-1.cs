        public class Item
    {
        public long Id { get; set; }
    }
    public class ItemWithContent : Item
    {
        public string Content { get; set; } 
    }
    public class TestContext : DbContext
    {
        public IDbSet<Item> Items { get; set; }
    }
