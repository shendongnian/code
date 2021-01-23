    public class Event
    {
        public ICollection<SectionEvent> SectionEvents { get; set; }
    }
    public class SectionEvent
    {
        public Event Event { get; set; }
        public Section Section { get; set; }
    }
    public class Section
    {
        public ICollection<SectionEvent> SectionEvents { get; set; }
    }
