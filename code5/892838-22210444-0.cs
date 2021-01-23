    public class MyModel
    {
        public List<SalesOrder> SalesOrders = new List<SalesOrder>();
    }
    
    public class SalesOrder
    {
        public string SOKey = string.Empty;
        public List<SalesOrderLine> SalesOrderLines = new List<SalesOrderLine>();
    }
