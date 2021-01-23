    public class Trade
    {
        public int TradeId { get; set; }
        public virtual UserProfile SendUser { get; set; }
        public virtual UserProfile ReturnUser { get; set; }     
        public virtual ICollection<Item> Items { get; set; }
    }
