     private static void Main(string[] args)
     {
         MyService testService;
         testService = new MyService("A");
         Console.WriteLine(testService.Name);   // prints 'Service A'
         testService = new MyService("B");
         Console.WriteLine(testService.Name);   // prints 'Service B'
         Console.ReadLine();
     }
