    public class User
    {
        ...
        public virtual ICollection<EventUser> EventUsers { get; set; }
    }
    public class EventUser
    {
        ...
        public virtual Event Event { get; set; }
    }
    public class Event
    {
        ...
        public virtual ICollection<EventObject> EventObjects { get; set; }
    }
