    class Program
    {
        static void Main(string[] args)
        {
            using (var wrapper = new Wrapper())
            {
                wrapper.DoSomething();
            }
            Console.WriteLine("Finished.");
            Console.ReadLine();
        }
    }
    class Wrapper : IDisposable
    {
        public void DoSomething()
        {
            Task<string> task1;
            using (var client = new ServiceReference1.Service1Client())
            {
                task1 = client.GetDataAsync(1);
                var task2 = client.GetDataAsync(2);
                Thread.Sleep(1000);
                var task3 = client.GetDataAsync(3);
                Console.WriteLine("Calls started");
            }
            Console.WriteLine("Result of task 1:" + task1.Result);
        }
        public void Dispose()
        {
        }
    }
