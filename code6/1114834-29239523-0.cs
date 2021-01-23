    public static void Main(string[] args)
    {
    	Task.Run(() =>
    	{
    		Thread.Sleep(1000);
    		Console.Out.WriteLine("Something has gone terribly wrong!");
    		System.Environment.Exit(1);
    	});
    
    	for (int i = 0; i < 100; i++)
    	{
    		Console.Out.WriteLine(i);
    		Thread.Sleep(100);
    	}
    }
