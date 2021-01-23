    public class Customer {
	    public string FirstName { get; set; }
    }
    public static void Main() {
	    var customer = new Customer() { FirstName = "Simon" };
	    Example(customer);
	    Console.WriteLine(customer.FirstName);
    }
	
    public static void Example(Customer customer) {
    	customer = new Customer() { FirstName = "CHANGED" };
    }
