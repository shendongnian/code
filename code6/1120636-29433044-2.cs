    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace ConsoleApplication14
    {
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int number = 999;
            List<string> print = new List<string>();
            for (i = 0; i < 9000; i++)
            {               
                number += 1;
                print.Add(number.ToString());
            }
            System.IO.File.WriteAllLines(@"C:\users\public\numbers.txt", print);
            Console.WriteLine("Press a button and open your text document");
            Console.ReadKey();
        }
    }
    }
