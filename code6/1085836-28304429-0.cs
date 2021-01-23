        static void Main(string[] args)
        {
            var staff = new Staff();
            staff.AddPerson(new Person(12, "John Doe"));
            staff.AddPerson(new Person(12, "Jande Doe"));
            foreach (var person in staff)
            {
                Console.WriteLine(person.Name);
            }
            Console.ReadLine();
        }
    }
    public class Person
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public Person(int age, string name)
        {
            Name = name;
            Age = age;
        }
    }
    public class Staff : IEnumerable<Person>
    {
        private List<Person> staff = new List<Person>();
        public void AddPerson(Person p)
        {
            this.staff.Add(p);
        }
        public IEnumerator<Person> GetEnumerator()
        {
            return this.staff.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.staff.GetEnumerator();
        }
    }
