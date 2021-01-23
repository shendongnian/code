    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main(String[] args)
            {
                int opt;
    
                Console.WriteLine("program name");
                Console.WriteLine();
                Console.WriteLine("1. exercise 1");
                Console.WriteLine("2. exercise 2");
                Console.WriteLine("3. exercise 3");
                Console.WriteLine("4. exercise 4"); // to 100
                Console.WriteLine();
    
                Console.WriteLine("Choose exercise number: ");
                opt = int.Parse(Console.ReadLine());
    
                MethodInfo info = (typeof(Program)).GetMethod("Exercise" + opt.ToString());
    
                //then call the exercise#
                info.Invoke(null, null);
                Console.ReadLine();
            }
    
            public static void Exercise1()
            {
                Console.WriteLine("Exercise 1 executing..");
            }
    
            public static void Exercise2()
            {
                Console.WriteLine("Exercise 2 executing..");
            }
        }
    }
