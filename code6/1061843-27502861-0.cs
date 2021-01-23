    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
