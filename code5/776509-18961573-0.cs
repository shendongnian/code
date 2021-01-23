    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()        
        {
            CultureInfo us = new CultureInfo("en-US");
            CultureInfo sa = new CultureInfo("ar-SA");
            string text = "1434-09-23T15:16";
            string format = "yyyy'-'MM'-'dd'T'HH':'mm";
            Console.WriteLine(DateTime.ParseExact(text, format, us));
            Console.WriteLine(DateTime.ParseExact(text, format, sa));
        }
    } 
