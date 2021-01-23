    class Program
     {
        static void Main(string[] args)
        {
            Service1 webservice = new Service1();   
            Console.Out.Write("\nHow many number of the Fibonacci sequence do you want returned?\n");
            var Number = Convert.ToInt32(Console.In.ReadLine());            
            var Sequence = webservice.Fibonacci(Number);    
            Console.Out.Write("\nThe Sequence is \n\n");
            for (int i = 0; i < Number; i++) // Fixed LINE ********
            { 
                Console.WriteLine(Sequence[i]);
            }
            Console.Out.Write(",  \n\nPress ENTER to return");
            Console.ReadLine();
        }
    }
