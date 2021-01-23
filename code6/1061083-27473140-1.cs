    public class Program
    {
    
    	public static void Main()
    	{
    		var customerA = new Customer("firstname","lastname",22);
    		var customerB = new Customer("firstname","lastname",22);
    		
    		Console.WriteLine(customerA==customerB);
    	}
    }
