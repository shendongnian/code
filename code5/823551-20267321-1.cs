    [Table(Name="Customers")]
    public class Customer
    {
       [Column(Id=true)]
       public string CustomerID;
       ...
       private EntitySet<Order> _Orders;
       [Association(Storage="_Orders", OtherKey="CustomerID")]
       public EntitySet<Order> Orders {
          get { return this._Orders; }
          set { this._Orders.Assign(value); }
       }
    }
