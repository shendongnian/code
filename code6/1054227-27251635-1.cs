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
                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine(i + ". exercise " + i);
                    // or use:
                    // Console.WriteLine("{0}. exercise {0}", i); 
                }
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
