    class Customer
    {
        private Lazy<Orders> _orders;
        public string CustomerID {get; private set;}
        public Customer(string id)
        {
            CustomerID = id;
            _orders = new Lazy<Orders>(() =>
            {
                // You can specify any additonal  
                // initialization steps here. 
                return new Orders(this.CustomerID);
            });
        }
        public Orders MyOrders
        {
            get
            {
                // Orders is created on first access here. 
                return _orders.Value;
            }
        }
    }
