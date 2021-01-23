        namespace intpass 
        { 
        class Program 
        { 
        static void Main(string[] args) 
        { 
          int myInt = methodPass(5); 
          int b = 20; int z; 
          z = (myInt + b); 
          Console.WriteLine(z); Console.ReadLine(); 
        } 
        private static int methodPass(int c)
        {
          return c + 45; } 
        }
     } 
