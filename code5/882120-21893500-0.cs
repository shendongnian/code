    public class Order
    {
        public int Number { get; set; }
        public int Line { get; set; }
        // ...
        public virtual ICollection<OrderDetails> Details { get; set; }
    }
