    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            CultureInfo culture = new CultureInfo("it-IT");
            Console.WriteLine(DateTime.Now.ToString(culture));
            Console.WriteLine("Runtime: {0}", Environment.Version);
        }
    }
