    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace Lab2
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> numbersInput = new List<string>();
    
                Console.WriteLine("Please enter an integer");
                string input = Console.ReadLine();
    
                while (!string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("The number you have entered is: " + " " + input);
    		        numbersInput.Add(input);
                    Console.WriteLine("Please enter another integer: ");
                    input = Console.ReadLine();
                }
            }
        }
    }
