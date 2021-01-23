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
                int zeroCount = 5;
                char charToPrint = '0';
                Console.Write(new string(charToPrint, zeroCount));
                Console.Read();
            }
        }
    }
