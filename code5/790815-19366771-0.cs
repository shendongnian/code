    public class Trade
    {
        public int Id { get; set; }
        public virtual ICollection<Item> ItemsToSend { get; set; }
        public virtual ICollection<Item> ItemsToReturn { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
