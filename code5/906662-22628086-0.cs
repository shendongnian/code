    public class Hobby
    {
        public string type { get; set; }
        public int id { get; set; }
        public string description { get; set; }
    }
    
    public class HobbiesCollection
    {
        public List<Hobby> Hobby { get; set; }
    }
    
    public class RootObject
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public HobbiesCollection HobbiesCollection { get; set; }
    }
