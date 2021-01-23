    public class OrderDetailsEqualityComparer : IEqualityComparer<OrderDetails>
    {
        public bool Equals(OrderDetails x, OrderDetails y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
     
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
     
            return (x.OrderId == y.OrderId );
        }
     
        public int GetHashCode(Product obj)
        {
            return obj.OrderId.GetHashCode();
        }
    }
