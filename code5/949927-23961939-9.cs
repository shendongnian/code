    public class CustAndOrders
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        // Customer table
        public Int64 Cust_Id
        {
            get
            { return Customer.CustId;}
            set
            { Customer.CustId = value; }
        }
    ... Do this for the rest of your properties
