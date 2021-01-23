    namespace Web
    {
        public class DerivedContext : Core.BaseContext
        {
            public DerivedContext()
                : base("BaseContext")
            {
            }
            public DbSet<Order> Order { get; set; }
        }
        public class Order
        {
            public int Id { get; set; }
            public double Quantity { get; set; }
            public string Item { get; set; }
        }
    }
