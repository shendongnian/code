    public class Order
    {
        public int Id { get; set; }
        public string PersonName { get; set; } // the "Customer"
        // ... more properties
        // an order has many OrderDetails/meals
        public virtual ICollection<OrderDetail> Details { get; set; }
    }
    public class OrderDetail // your "order-meal"
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public int Quantity { get; set; } // your Count
        // ...more properties like for example decimal Discount
    }
    public class Meal // the "Product"
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // ...more properties
    }
