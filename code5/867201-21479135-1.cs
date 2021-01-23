    public class OrderDetails : IEquatable<OrderDetails>
    {
        public int OrderId { get; set; }
       
        public int ProductId { get; set; }
        public bool Equals(OrderDetails anotherOrder)
        {
            return this.OrderId.Equals(anotherOrder.OrderId);
        }
        public override int GetHashCode()
        {
            return this.OrderId;
        }
    }
