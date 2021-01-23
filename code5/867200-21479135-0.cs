    public class OrderDetails : IComparable<OrderDetails>
    {
        public int OrderId { get; set; }
       
        public int ProductId { get; set; }
        public int CompareTo(OrderDetails anotherOrder)
        {
            return this.OrderId.CompareTo(anotherOrder.OrderId);
        }
    }
