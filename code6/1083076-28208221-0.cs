    public class Order
    {
        public int orderId;
    }
    public class OrderDetails
    {
        public int orderId;
        public double subTotal;
    }
    [TestMethod]
    public void Test()
    {
        var orders = new List<Order> {
            new Order{orderId = 1} , 
            new Order{orderId = 2}
        };
        var orderDetails = new List<OrderDetails> {
            new OrderDetails{orderId = 1 , subTotal = 10.1} , 
            new OrderDetails{orderId = 1 , subTotal = 1} , 
            new OrderDetails{orderId = 1 , subTotal = 10.2} , 
            new OrderDetails{orderId = 1 , subTotal = 20} , 
            new OrderDetails{orderId = 2 , subTotal = 5},
            new OrderDetails{orderId = 2 , subTotal = 7.6},
            new OrderDetails{orderId = 2 , subTotal = 3.2},
            new OrderDetails{orderId = 2 , subTotal = 9}
        };
        var result = orderDetails.
            GroupBy(o => new
            {
                orderId = o.orderId
            },
            (key, items) => new
            {
                orderId = key.orderId,
                subTotals = items.Select(p => p.subTotal).ToList()
            }).
            ToList();
    }
