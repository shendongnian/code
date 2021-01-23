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
                Console.WriteLine("Factorial of six is :" + manipulator.factorial(16));
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
                result = result * b;//fact has the value 1  as constant and fact into b will be save in fact to multiply again. 
                Console.WriteLine(result);
                b++;
            } while (num >= b);
            return result;
        }
      }
    }
