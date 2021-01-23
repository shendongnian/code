    public class OrderAddress : BaseModel
    {
        ...
        public virtual ICollection<Order> BillingOrders { get; set; }
        public virtual ICollection<Order> ShippingOrders { get; set; }
        ...
    }
