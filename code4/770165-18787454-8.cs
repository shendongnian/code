    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            Console.WriteLine(Force4DecimalPlaces("0.0000001")); // 0.0000
            Console.WriteLine(Force4DecimalPlaces("1.000000"));  // 1.0000
            Console.WriteLine(Force4DecimalPlaces("1.5"));       // 1.5000
            Console.WriteLine(Force4DecimalPlaces("1.56789"));   // 1.5679
        }
         
        public static decimal Force4DecimalPlaces(string input)
        {
            decimal parsed = decimal.Parse(input, CultureInfo.InvariantCulture); 
            string intermediate = parsed.ToString("0.0000", CultureInfo.InvariantCulture);
            return decimal.Parse(intermediate, CultureInfo.InvariantCulture);
        }
    } 
