    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            string input = "2500";
            decimal cents = decimal.Parse(input); // Potentially use TryParse...
            decimal dollars = cents / 100m;
            string output = dollars.ToString("0.00");
            Console.WriteLine(output); // 25.00
        }
    }
