    using System.IO;
    using System;
    using System.Globalization;
    class Program
    {
        static void Main()
        {
            double value = 133354.4;
            Console.WriteLine(value.ToString("#,#.00", CultureInfo.InvariantCulture));
      
        }
    }
