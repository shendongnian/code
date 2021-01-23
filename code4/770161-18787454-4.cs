    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            Console.WriteLine(Force4DecimalPlaces(0.0000001m)); // 0.0000
            Console.WriteLine(Force4DecimalPlaces(1.000000m));  // 1.0000
            Console.WriteLine(Force4DecimalPlaces(1.5m));       // 1.5000
            Console.WriteLine(Force4DecimalPlaces(1.56789m));   // 1.5679
       }
        
        public static decimal Force4DecimalPlaces(decimal input)
        {
            string text = input.ToString("0.0000", CultureInfo.InvariantCulture);
            return decimal.Parse(text, CultureInfo.InvariantCulture);
        }
    } 
