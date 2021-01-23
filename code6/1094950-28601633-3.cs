    public class OrderRepository : IOrderRepository
    {
        ...
        public IOrder CreateNewOrder()
        {
            return new Order();
        }
    }
