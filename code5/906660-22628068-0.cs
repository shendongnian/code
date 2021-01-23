    public class Rootobject
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public Hobbiescollection HobbiesCollection { get; set; }
    }
    
    public class Hobbiescollection
    {
        public Hobby[] Hobby { get; set; }
    }
    
    public class Hobby
    {
        public string type { get; set; }
        public int id { get; set; }
        public string description { get; set; }
    }
