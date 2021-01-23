    public class CustomCustomer
    {
	    public Customer customers { get; set; }
	    public int Sum
	    {
		  get
		  {
			return customers.Select(v => v.ID).Sum();
		  }
	   }
    }
