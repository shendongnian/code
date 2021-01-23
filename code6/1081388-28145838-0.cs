    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DigitSum
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number : ");
    
            var num = Console.ReadLine();
    
            var sum = num.Select(c => int.Parse(c.ToString())).Sum();
    
            Console.WriteLine("The sum of the digits in the number: " + num + " is " + sum);
            Console.ReadLine();
        }
      }
    }
