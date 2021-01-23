    public class OrderProcessor
    {
        private IOrder order;
        public OrderProcessor(IOrder _order)
        {
            order = _order;
         }
        public void Process()
        {
            order.ProcessOrder(id, User.Current.Id);
         }
    }
