    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } // <- add this property
        public DateTime OrderedOn { get; set; } // <- change this property name
        // OrderNumber, OrderedOn is a unique key
        public decimal TotalPrice { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
