    using System;
    using System.Globalization;
    class Program
    {
        static void Main()
        {
    	string dateString = "Mon 16 Jun 8:30 AM 2008"; // Modified from MSDN
    	string format = "ddd dd MMM h:mm tt yyyy";
	    DateTime dateTime = DateTime.ParseExact(dateString, format,
	    CultureInfo.InvariantCulture);
    	Console.WriteLine(dateTime);
        }
    }
