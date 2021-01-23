    public class Program
    {
        public static ManualResetEventSlim StopSwitch = new ManualResetEventSlim();
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (s, a) =>
            {
                a.Cancel = true;
                StopSwitch.Set();
            };
            using (WebApp.Start<Startup>("http://+:8080/"))
            {
                Console.WriteLine("Server is running...");
                Console.WriteLine("Press CTRL+C to stop it.");
                StopSwitch.Wait();
                Console.WriteLine("Server is stopping...");
                ShutDownMiddleware.ShutDown();
                while (ShutDownMiddleware.GetRequestCount() != 0)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
