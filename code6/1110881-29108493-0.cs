    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Press any Key:");
                while(true)
                {
                    var keyInfo = Console.ReadKey(true);
                    var key = keyInfo.Key;
                    Console.WriteLine(key.ToString());
                }
            }
        }
    }
