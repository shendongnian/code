    using System;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = Convert.ToDouble("2");
            var num2 = Convert.ToDouble("1.2");
            var answer = num1 + num2;
            Console.WriteLine(Convert.ToString(answer));
            Console.ReadKey();
        }
    }
    }
