    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            // Make this int instead of void
            static int Main(string[] args)
            {
                if(args.Length == 0)
                {
                    Console.WriteLine("Please enter a numeric argument: ");
                    return 1;
                }
                // Default return value
                return 0;
            }
        }
    }
