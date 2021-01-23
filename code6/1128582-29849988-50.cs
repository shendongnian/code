    public class Register
    {
        public int id { get; set; }
        public List<Person> teachers { get; set; }
        public List<Person> students { get; set; }
    }
    
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
