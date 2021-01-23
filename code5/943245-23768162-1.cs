    public partial class Northwind : DataContext
    {
        public Table<Customer> Customers;
        public Table<Order> Orders;
        public Northwind(string connection) : base(connection) { }
    }
