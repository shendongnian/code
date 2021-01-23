    public class Order
    {
        public int OrderId { get; set; }
        public int ShippingTypeId { get; set; }
        public ShippingType ShippingType { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
