    class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Factory.StartNew(() => Thread.Sleep(5000));
            var task2 = Task.Factory.StartNew(() => Thread.Sleep(10000));
            Task.WhenAll(task1, task2).Wait();
            Console.WriteLine("Finished");
        }
    }
