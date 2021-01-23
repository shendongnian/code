    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            var hebrewCalendar = CalendarSystem.HebrewCivil;
            var today = new LocalDate(5775, 5, 18, hebrewCalendar);
            Console.WriteLine(today.Year); // 5775
            Console.WriteLine(today.WithCalendar(CalendarSystem.Gregorian).Year); // 2015
        }
    }
