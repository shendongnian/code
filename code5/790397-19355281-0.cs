    public class OrderDetails {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
    }
    var query = (from a in Orders.Expand("Order_Details")
    select new OrderDetails { OrderID = a.order_id, CustomerID = a.customer_id } ).Take(9)
