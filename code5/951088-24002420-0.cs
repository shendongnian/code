    public class Person
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
    }
    class Program
    {
        public List<Person> Collection { get; set; }
        public List<Person> CreateCollection()
        {
            return new List<Person>()
            {
                new Person() { Name = "Demo", Firstname = "Demo1"},
                new Person() { Name = "Demo", Firstname = "Demo1"},
            };
        }
        static void Main(string[] args)
        {
             // Do work here.
        }
    }
