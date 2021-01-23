    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public string datefrom { get; set; }
        public string timeto { get; set; }
        public string price { get; set; }
        public string imagen { get; set; }
        public string desc { get; set; }
        public string info { get; set; }
        public int user { get; set; }
        public int place { get; set; }
        public string dateto { get; set; }
        public List<object> Eventcategories { get; set; }
    }
    
    public class EventResponse
    {
        public List<Event> Events { get; set; }
    }
