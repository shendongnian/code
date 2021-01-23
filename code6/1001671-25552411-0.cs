    static void Main(string[] args)
    {
      MainAsync().Wait();
    }
    static async Task MainAsync()
    {
      Console.WriteLine("Hello, world! Hit ANY key to continue...");
      Console.ReadLine();
      var XMLString = await RunAsync();
      //Some XML parsing stuff here
    }
