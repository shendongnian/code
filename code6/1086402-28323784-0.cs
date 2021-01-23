    class Person
    {
        public Person()
        {
            Events = new List<Event>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public virtual List<Event> Events { get; set; }
    }
