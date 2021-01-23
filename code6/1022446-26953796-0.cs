    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
           
            NumberManipulator manipulator = new NumberManipulator();
            Console.WriteLine("Please Enter Factorial Number:");
            int a= Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("---Basic Calling--");
            Console.WriteLine("Factorial of {0} is: {1}" ,a, manipulator.factorial(a));
         
            Console.WriteLine("--Recursively Calling--");
            Console.WriteLine("Factorial of {0} is: {1}", a, manipulator.recursively(a));
            
            Console.ReadLine();
        }
    }
    class NumberManipulator
    {
        public int factorial(int num)
        {
            int result=1;
            int b = 1;
            do
            {
                result = result * b;
                Console.WriteLine(result);
                b++;
            } while (num >= b);
            return result;
        }
        public int recursively(int num)
        {
            if (num <= 1)
            {
                return 1;
            }
            else
            {
                return recursively(num - 1) * num;
            }
        }
      }
    }
