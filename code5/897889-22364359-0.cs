    static async Task Test()
    {
        CallContext.LogicalSetData("Name", "Thread Flintstone");
        await Task.Run(delegate
        {
            //Console.WriteLine("Crashing with NRE...");
            Console.WriteLine("The current user is: {0}", CallContext.LogicalGetData("Name"));
        });
    }
    static void Main(string[] args)
    {
        Test().Wait();
        Console.ReadLine();
    }
