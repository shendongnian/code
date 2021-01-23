    [Table("EventDates")]
    public class EventDate
    {
        public int EventDateId { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
        public DateTime EventDateStart { get; set; }
        public DateTime? EventEnd { get; set; }
        public string TicketPurchaseUrl { get; set; }
    }
    [Table("Events")]
    public class Event
    {
        public int EventId { get; set; }
        public virtual ICollection<EventDate> EventDates { get; set; }
    }
