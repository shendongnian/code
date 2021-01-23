    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		ServiceHost myServiceHost = new ServiceHost(typeof(CalculatorService));
    
    		// Open the ServiceHostBase to create listeners and start listening for messages.
    		myServiceHost.Open();
    
    		// The service can now be accessed.
    		Console.WriteLine("The service is ready.");
    		Console.WriteLine("Press <ENTER> to terminate service.");
    		Console.WriteLine();
    
    		Console.ReadLine();
    
    		Console.WriteLine("Sending data from client to service.");
    		Client c = new Client();
    		var res = c.Add(1, 2);
    
    		Console.ReadLine();
    	}
    
    }
