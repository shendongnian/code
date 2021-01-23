    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                int read;
                int sum = 0;
                int i = 0;
                Console.WriteLine("Enter 5 numbers: "); 
                while(i<5)
                {
                   read = int.Parse(Console.ReadLine());
                   sum = sum + read;
                   i++;
                }
    
                Console.WriteLine("The total sum of the 5 numbers are " + sum);
            }
        }
    }
