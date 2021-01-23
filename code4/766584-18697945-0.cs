    class Program
    {
        static async Task Test1()
        {
            System.Console.WriteLine("Enter Test");
            await Task.Delay(100);
            System.Console.WriteLine("Leave Test");
        }
        static async Task Test2()
        {
            System.Console.WriteLine("Enter callback");
            await Task.Delay(1000);
            System.Console.WriteLine("Leave callback");
        }
        static async Task Test()
        {
            await Test1(); // could do .ConfigureAwait(false) if continuation context doesn't matter
            await Test2();
        }
        static void Main(string[] args)
        {
            Test().Wait();
            Console.WriteLine("Done with test");
        }
    }
 
