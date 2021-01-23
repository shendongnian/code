    public class Cart
    {
        public int ID { get; set; }
        // no nav property for Shopper
    }
    public class Shopper
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
    }
