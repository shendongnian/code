    public class CustAndOrders
    {
        private readonly Customer _customer;
        public CustAndOrders(Customer customer)
        {
            _customer = customer;
        }
        // Customer table
        public Int64 Cust_Id
        {
            get
            { return _customer.CustId;}
            set
            { _customer.CustId = value; }
        }
    ...
