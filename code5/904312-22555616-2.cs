    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();
        }
        static async Task MainAsync()
        {
            await Method1();
            await Method2();
        }
        static Task Method1()
        {
            return Method2();
        }
        static Task Method2()
        {
            return Method3();
        }
        static async Task Method3()
        {
            Console.Write("Start");
            await Task.Delay(1000);
            Console.Write("End");
        }
    }
