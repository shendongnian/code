    private static void Main(string[] args)
    {
    	CallAsync();
    	Console.Read();
    }
    
    public static async void CallAsync()
    {
    	try
    	{
    		await DoSomething();
    	}
    	catch (Exception)
    	{
    		// Handle exceptions ?
    		Console.WriteLine("In the catch");
    	}
    }
    
    public static Task DoSomething()
    {
    	return Task.Run(() =>
    	{
    		throw new Exception();
    	});
    }
