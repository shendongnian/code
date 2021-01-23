     public class Order
    {
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        [ForeignKey("Agent")]
        public int AgentID { get; set; }
        public virtual ApplicationUser Agent { get; set; }
    }
