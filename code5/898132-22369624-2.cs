    using System;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i;
    
                for (i = 100; i > 0; i--)
                {
                	if(i%10==0)Console.WriteLine();
                	Console.Write(i);
                }
                Console.ReadLine();
    
            }
        }
    }
