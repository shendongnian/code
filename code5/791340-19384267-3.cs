    using ClassLibrary1;
    using ConsoleApplication10.ServiceReference1;
    
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myService = new Service1Client();
    
                Console.WriteLine(myService.GetElement(new CompositeTypeA()).Name);
                Console.WriteLine(myService.GetElement(new CompositeTypeB()).Name);
                Console.WriteLine(myService.GetElement(new CompositeTypeC()).Name);
            }
        }
    }
