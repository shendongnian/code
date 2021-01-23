    public class ShippedItemsIndex
        : AbstractIndexCreationTask<Order, ShippedItemsIndex.Result>
    {
        public class Result
        {
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public DateTime ShipDate { get; set; }
        }
        public ShippedItemsIndex()
        {
            Map = orders => 
                from order in orders
                from line in order.OrderLines
                where line.ShipDate != null
                select new
                {
                    order.OrderId,
                    order.CustomerName,
                    line.ProductName,
                    line.Quantity,
                    line.ShipDate
                };
            StoreAllFields(FieldStorage.Yes);
        }
    }
