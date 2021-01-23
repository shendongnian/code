    public class OrderViewModel
    {
        private Order _order;
        public string Address 
        {
            get { return _order.Customer.Address; }
        }
        // similar with other properties
        public OrderViewModel(Order order)
        {
            _order = order;
        }
    }
