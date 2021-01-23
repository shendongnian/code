        static void Main(string[] args)
        {
            using (var service = new ServiceReference1.Service1Client())
            {
                var response = service.GetData(5);
                Console.WriteLine(response);
                Console.ReadLine();
            }
        }
