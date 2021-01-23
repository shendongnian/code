    using System;
    using System.Globalization;
    
    namespace DateTimeToString
    {
        class Program
        {
            // Tested on
            // Microsoft Windows 7 Enterprise x64 Version 6.1.7601 Service Pack 1 Build 7601
            // I should have all official updates installed at the time of writing (2014-03-11)
            //
            // Microsoft Visual Studio Premium 2012 Version 11.0.61030.00 Update 4
            // Microsoft .NET Framework Version 4.5.50938
            //
            // Type: Console application x86
            // Target framework: .NET 4 Client Profile
            static void Main()
            {
                if (DateTimeFormatInfo.CurrentInfo.LongTimePattern != "HH-mm:ss" ||
                    DateTimeFormatInfo.CurrentInfo.ShortDatePattern != "dd.MM/yyyy")
                {
                    Console.WriteLine("Configure long time format to MM-mm:ss to reproduce the time bug.");
                    Console.WriteLine("Configure short date format to dd.MM/yyyy to reproduce the date bug.");
                    Console.WriteLine("Control Panel/Region and Language/Additional settings");
                    return;
                }
    
                var dateTime = DateTime.Now;
                Console.WriteLine("Expected: " + dateTime.ToString("HH'-'mm':'ss"));
                Console.WriteLine("Actual  : " + dateTime.ToString("T"));
                Console.WriteLine();
    
                Console.WriteLine("Expected: " + dateTime.ToString("dd'.'MM'/'yyyy HH'-'mm':'ss"));
                Console.WriteLine("Actual  : " + dateTime.ToString("G"));
                Console.WriteLine();
    
                Console.WriteLine("Expected: " + dateTime.ToString("HH'-'mm':'ss"));
                Console.WriteLine("Actual  : " + dateTime.ToLongTimeString());
                Console.WriteLine();
    
                Console.WriteLine("Expected: " + dateTime.ToString("dd'.'MM'/'yyyy"));
                Console.WriteLine("Actual  : " + dateTime.ToShortDateString());
                Console.ReadLine();
            }
        }
    }
