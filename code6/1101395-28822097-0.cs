    void Main()
    {
    	IEnumerable<User> Users = 
            new List<User> { new User { UserId = 0, UserDisabled = "N" } };
    	IEnumerable<Part> Parts = 
            new List<Part> { new Part { SalesRepId = 0, PARVWxx = "ZP", KUNNRxx = "@Customer" } };
    	IEnumerable<UserCustomer> UserCustomers = 
            new List<UserCustomer> { new UserCustomer { UserId = 0, Customer = 0 } };
    	
    	var query = 
    		from p in Parts
    		join y in UserCustomers 
    		on p.SalesRepId equals y.Customer
    		select new { p, y } into inner
    			join z in Users 
    			on inner.y.UserId equals z.UserId
    			where ! z.UserDisabled.Equals("Y") && 
                inner.p.PARVWxx.Equals("ZP") && 
                inner.p.KUNNRxx.Equals("@Customer")
    			select inner.p.SalesRepId;
    	
	    foreach(var result in query)
	    {
		    Console.WriteLine(result);
	    }
    }
    
    // Define other methods and classes here
    public class Part 
    {
    	public int SalesRepId { get; set; }
    	public string PARVWxx { get; set; }
    	public string KUNNRxx { get; set; }
    }
    
    public class User
    {
        public int UserId { get; set; }
    	public string UserDisabled { get; set; }
    }
    
    public class UserCustomer
    {
    	public int UserId { get; set; }
    	public int Customer { get; set; }
    }
