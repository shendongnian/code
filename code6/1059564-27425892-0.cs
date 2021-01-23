    public class Athlete
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
    
    public class Record
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Athlete Athlete { get; set; }
    }
