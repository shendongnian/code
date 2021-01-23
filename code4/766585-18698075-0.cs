    class Program
    {
      static public async Task Test()
      {
        System.Console.WriteLine("Enter Test");
        await Task.Delay(100);
        System.Console.WriteLine("Leave Test");
      }
      static async Task MainAsync()
      {
        await Test();
        System.Console.WriteLine("Enter callback");
        await Task.Delay(1000);
        System.Console.WriteLine("Leave callback");
      }
      static void Main(string[] args)
      {
        MainAsync().Wait();
        Console.WriteLine("Done with test");
      }
    }
