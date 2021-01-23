    using System;
    using System.Globalization;
    
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dateValue = "10/03/1987";
                var date = DateTime.ParseExact(dateValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    
                var timeValue = "12:48 AM";
                var time = DateTime.ParseExact(timeValue, "h:mm tt", CultureInfo.InvariantCulture);
    
                var dateTime = date + time.TimeOfDay;
    
                Console.WriteLine(date);
                Console.WriteLine(time);
                Console.WriteLine(dateTime);
            }
        }
    }
