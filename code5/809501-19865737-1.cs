    private static void Main(string[] args)
    {
    	CallAsync();
    	Console.Read();
    }
    
    public static void CallAsync()
    {
    	try
    	{
    		DoSomething();
    	}
    	catch (Exception)
    	{
    		// Handle exceptions ?
    		Console.WriteLine("In the catch");
    	}
    }
    
    public static async void DoSomething()
    {
    	await Task.Run(() =>
    	{
    		throw new Exception();
    	});
    }
