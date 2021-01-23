    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host1 = new ServiceHost(typeof(Calculator));
            host1.Open();
            ServiceHost host2 = new ServiceHost(typeof(Calculator_Fake));
            host2.Open();
            Console.ReadLine();
        }
    }
