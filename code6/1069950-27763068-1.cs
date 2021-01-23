    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.Shutdown += Handler1;
            a.Shutdown += Handler2;
            a.Shutdown += Handler3;
            a.OnShutdown().Wait();
        }
        static async Task Handler1(object sender, EventArgs e)
        {
            Console.WriteLine("Starting shutdown handler #1");
            await Task.Delay(1000);
            Console.WriteLine("Done with shutdown handler #1");
        }
        static async Task Handler2(object sender, EventArgs e)
        {
            Console.WriteLine("Starting shutdown handler #2");
            await Task.Delay(5000);
            Console.WriteLine("Done with shutdown handler #2");
        }
        static async Task Handler3(object sender, EventArgs e)
        {
            Console.WriteLine("Starting shutdown handler #3");
            await Task.Delay(2000);
            Console.WriteLine("Done with shutdown handler #3");
        }
    }
