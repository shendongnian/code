    using System;
    using System.Globalization;
    using System.Threading;
    
    namespace DTFTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dt = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("EN-US", true);
                var ci = Thread.CurrentThread.CurrentCulture;
                var monthNames = new[] { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D", string.Empty };
                ci.DateTimeFormat.AbbreviatedMonthNames = monthNames;
                Console.WriteLine(dt.ToString("MMM-dd-yyyy"));
            }
        }
    }
