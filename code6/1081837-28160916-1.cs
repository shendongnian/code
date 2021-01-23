    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    	
    	public Contact() {}
    	
    	public Contact(string firstName, string lastName)
    	{
    		this.FirstName = firstName;
    		this.LastName = lastName;
    	}
    }
    
    Customer x = new Customer();
    x.ID = "MyId";
    x.AccountName = "HelloAccount";
    x.BillToContact = new Contact("Jim", "Bob");
    Customer.Add(x);
