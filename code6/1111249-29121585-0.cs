 	[Table( Name = "Customers" )]
    public class Customer
    {
	    [PrimaryKey, Identity]
	    [Column(Name = "CustomerId"), NotNull]
	    public string Id { get; set; }
	    [Column(Name = "Name")]
	    public string Name { get; set; }
	}
 	[Table( Name = "Activities" )]
	public class Activity
    {
	    [PrimaryKey, Identity]
	    [Column(Name = "ActivityId"), NotNull]
	    public string Id { get; set; }
	    [Column( Name = "Customer" )] 
	    private int? customerId; 
	    private EntityRef<Customer> _customer = new EntityRef<Customer>( );
	    [Association(IsForeignKey = true, Storage = "_customer", ThisKey = "customerId" )]
		public Customer Customer{
		    get { return _customer.Entity; }
		    set { _customer.Entity = value; }
		}
	}
