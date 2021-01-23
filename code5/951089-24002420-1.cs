    public class Person
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
    }
    class Program
    {
        public static List<Person> Collection { get; set; }
        public static List<Person> CreateCollection()
        {
            return new List<Person>()
            {
                new Person() { Name = "Demo", Firstname = "Demo1"},
                new Person() { Name = "Demo", Firstname = "Demo1"},
            };
        }
        static void Main(string[] args)
        {
             Collection = CreateCollection();
        }
    }
