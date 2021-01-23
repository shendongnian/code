    public class Customer 
    {
        public string  ID { get; set; }
        public string  AccountName { get; set; }
        public Contact BillToContact { get; set; }
    	
    	//Contructor
    	public Customer()
    	{
    		//Instantiate BillToContact 
    		BillToContact = new Contact();
    	}
    }
    
    Customer x = new Customer();
    x.ID = "MyId";
    x.AccountName = "HelloAccount";
    
    //This would now work because BillToContact has been instantiated from within the constructor of the Customer class
    x.BillToContact.FirstName = "Jim";
    x.BillToContact.LastName  = "Bob";
    
    Customer.Add(x);
