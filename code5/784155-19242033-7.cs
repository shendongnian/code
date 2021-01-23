    public class CalendarEvent
    {
        public DateTime EventDate { get; set; }
        public string Title { get; set; }
    }
    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
        public Foo Foo { get; set; }
    }
    public class Foo
    {
        public Bar Bar { get; set; }
    }
    public class Bar
    {
        public DateTime InternalDate { get; set; }
    }
