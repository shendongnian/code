    class Order<T> where T: OrderItem
    {
        public Order()
        {
            OrderItems = new List<T>();
        }
        public List<T> OrderItems {get;set;}
    }
    
    class SalesOrder : Order<SalesOrderItem> { }
    
    class OrderItem {}
    
    class SalesOrderItem : OrderItem {}
