    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Test
    {
        static void Main()
        {
            var persianCalendar = CalendarSystem.GetPersianCalendar();
            var pattern = LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd")
                .WithTemplateValue(new LocalDate(1393, 1, 1, persianCalendar));
            LocalDate result = pattern.Parse("1393-02-29").Value;
            DateTime dateTime = result.AtMidnight().ToDateTimeUnspecified();
            Console.WriteLine(dateTime); // 19th May 2014 (Gregorian)
        }
    }
