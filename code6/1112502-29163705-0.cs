    public class Order
    {
        public int OrderID { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        public virtual ApplicationUser Agent { get; set; }
    }
