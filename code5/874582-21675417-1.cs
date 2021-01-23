    class Program
    {
        class ConsoleCallback : ServiceReference1.IService1Callback
        {
            public void WriteLine(string message)
            {
                Console.WriteLine(message);
            }
        }
        static void Main(string[] args)
        {
            string[] arr = new string[3] { "harry", "ronn", "sheldon" };
            var service = new ServiceReference1.Service1Client(new InstanceContext(new ConsoleCallback()));
            service.Display(arr);
            Console.Read();
        }
    }
