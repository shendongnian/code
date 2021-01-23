    using System;
    using System.Globalization;
    using System.Threading;
    
    class Test
    {
        static void Main()        
        {
            DateTime now = DateTime.Now;
            CultureInfo culture = new CultureInfo("ar-SA"); // Saudi Arabia
            Thread.CurrentThread.CurrentCulture = culture;
            Console.WriteLine(now.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
        }
    } 
