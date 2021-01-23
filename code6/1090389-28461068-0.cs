	//Customer class
	public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Relationships
        public virtual ICollection<CustomerChange> CustomerChanges { get; set; }
    }
	//Mapping details for Customer
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(c => c.Id);
        }
    }
	
