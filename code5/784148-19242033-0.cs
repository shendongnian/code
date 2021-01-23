    public class Program
    {
        public static void Main(string[] args)
        {
            // Model
            var calendarEvent = new CalendarEvent
            {
                EventDate = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };
            MyObjectMapper mTut = new MyObjectMapper(@"SampleMappings.xml");
            Console.WriteLine(string.Format("Result MyMapper: {0}", Program.CompareObjects(calendarEvent, mTut.TestMyObjectMapperProjection(calendarEvent))));
            Console.ReadLine();
        }
        public static bool CompareObjects(CalendarEvent calendarEvent, CalendarEventForm form)
        {
            return calendarEvent.EventDate.Date.Equals(form.EventDate) &&
                   calendarEvent.EventDate.Hour.Equals(form.EventHour) &&
                   calendarEvent.EventDate.Minute.Equals(form.EventMinute) &&
                   calendarEvent.Title.Equals(form.Title);
        }
    }
