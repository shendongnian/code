    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
