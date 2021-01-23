    public class Event
    {
        ...
        public virtual ICollection<EventObject> EventObjects { get; set; }
        public virtual ICollection<EventUser> EventUsers { get; set; }
    }
    public class EventUser
    {
        ...
        public int UserID { get; set; }
        public bool IsAccepted { get; set; }
    }
