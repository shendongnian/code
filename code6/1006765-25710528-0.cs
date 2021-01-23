    using System;
    using System.Linq;
    
    class Program
    {
    
    
        private static void Main(string[] args)
        {
            string[] Ar = new string[10];
    
            var item = from f in Ar
                       select string.IsNullOrWhiteSpace(f) ? "NULL" : f;
    
            foreach (var i in item)
            {
                Console.WriteLine(i);
            }
    
            Console.ReadLine();
    
        }
    }
