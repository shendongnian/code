    class Program
    {
        static void Main(string[] args)
        {
            bool cancelToken = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!cancelToken)
                {
                    Console.WriteLine("Running....");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();
            Console.ReadKey();
            cancelToken = true;
            t.Join();
        }
    }
