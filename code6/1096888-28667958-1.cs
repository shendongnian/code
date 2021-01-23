    class Customer
    {
        public string FirstName;
        public string LastName;
        public Order[] Orders;
    }
    class Order
    {
        public string Description;
        public decimal Price;
        public int Quantity;
        public PayType PayType { get; set; }
        //public IPay Pay;
        // Payment type p=new pay
    }
    enum PayType{
        MasterCard,
        Visa,
        Paypal
    }
