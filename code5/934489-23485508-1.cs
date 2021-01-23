    public class Customer {
	    public string FirstName { get; set; }
    }
    public static void Main() {
	    var customer = new Customer() { FirstName = "Simon" };
	    Example(ref customer); // By ref
	    Console.WriteLine(customer.FirstName);
    }
	
    public static void Example(ref Customer customer) { // By ref
    	customer = new Customer() { FirstName = "CHANGED" };
    } 
