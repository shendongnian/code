    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            var original = new CultureInfo("en-us");
            // Prints ($5.50)
            Console.WriteLine(string.Format(original, "{0:C}", -5.50m));
            
            var modified = (CultureInfo) original.Clone();
            modified.NumberFormat.CurrencyNegativePattern = 1;        
            // Prints -$5.50
            Console.WriteLine(string.Format(modified, "{0:C}", -5.50m));
        }
    }
