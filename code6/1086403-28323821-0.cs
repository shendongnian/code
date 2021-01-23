    public class Person
    {
        public Person()
        {
              Events = new List<Event>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
    
        public virtual List<Event> Events { get; set; }
    }
    
    public class Event
    {    
        public int id { get; set; }
        public DateTime At { get; set; }
        public string Description { get; set; }
    
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
