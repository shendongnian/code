    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
    class Program
    {
        static void Main(string[] args)
        {
            //Declare i
            int i;
            Console.WriteLine("Please enter 5 random numbers");
            //Make some array
            string[] numbers = new string[5];
            for (i = 0; i < 5; i++)
            {
                Console.Write("\nEnter your number:\t");
                //Storing value in an array
                numbers[i] = Console.ReadLine();
            }
            //ta da your array is now completed.. lets see what is the largest..
            var converted = numbers.Select(int.Parse);
            int largest = converted.Max();
            //ta da
            Console.WriteLine("The largest number is..." + (largest));
        }
    }
    }
