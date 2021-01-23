    class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public List<OrderItem> OrderItems {get;set;}
    }
    
    class SalesOrder : Order { }
    
    class OrderItem {}
    
    class SalesOrderItem : OrderItem {}
