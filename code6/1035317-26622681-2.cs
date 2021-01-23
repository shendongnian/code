    public class Order
    {
            public int UserId { get; set; }
            public int OrderId { get; set; }
            public string Email { get; set; }
            public int PostCode { get; set; }
            public string Country { get; set; }
            public List<Order> OrderList { get; set; }
    }
