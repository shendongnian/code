    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace add
    
    {
        class Program
        {
            static void Main(string[] args)
            {
                int a,b,c;
                Console.WriteLine("Enter the first number");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number");
                b = Convert.ToInt32(Console.ReadLine());
                c = a + b;
                Console.WriteLine("The addition of two number is {0}", c);
                Console.ReadLine();
            }
        }
    }
