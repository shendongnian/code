    public class Start
    {
        public string allday { get; set; }
        public string shortdate { get; set; }
        public string longdate { get; set; }
        public string dayname { get; set; }
        public string time { get; set; }
        public string utcdate { get; set; }
        public string datetime { get; set; }
        public string timezone { get; set; }
    }
    
    public class End
    {
        public string allday { get; set; }
        public string shortdate { get; set; }
        public string longdate { get; set; }
        public string dayname { get; set; }
        public string time { get; set; }
        public string utcdate { get; set; }
        public string datetime { get; set; }
        public string timezone { get; set; }
    }
    
    public class Event
    {
        public string summary { get; set; }
        public string subscriptionId { get; set; }
        public string calPath { get; set; }
        public string guid { get; set; }
        public string recurrenceId { get; set; }
        public string link { get; set; }
        public string eventlink { get; set; }
        public string status { get; set; }
        public Start start { get; set; }
        public End end { get; set; }
    }
    
    public class BwEventList
    {
        public List<Event> events { get; set; }
    }
    
    public class RootObject
    {
        public BwEventList bwEventList { get; set; }
    }
