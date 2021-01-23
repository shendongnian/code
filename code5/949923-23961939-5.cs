    public class CustAndOrders
    {
        private readonly Customer _customer;
        private readonly Order _order;
        private readonly OrderDetail _orderDetail;
        public CustAndOrders(Customer customer, Order order, OrderDetail orderdetail)
        {
            _customer = customer;
            _order = order;
            _orderDetail = orderDetail;
        }
        // Customer table
        public Int64 Cust_Id
        {
            get
            { return _customer.CustId;}
            set
            { _customer.CustId = value; }
        }
    ... Do this for the rest of your properties
