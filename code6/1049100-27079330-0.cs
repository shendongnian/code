    sing System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Activity2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int n, sum, x = 0;
    
                do
                {
                    Console.WriteLine("Enter a Number: ");
                    n = int.Parse(Console.ReadLine());
    
    
                }
                while (n != 0);
                {
    
                    sum = n + x;
                    x = n;
                    n = sum;
                    
    
                }
                Console.WriteLine("The sum is: " + n);
                Console.ReadLine();
                }
        }
    
    }
