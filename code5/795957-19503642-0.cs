    class Program
    {
        public enum TableType
        {
            Person,
            Event,
            User
        }
        class Person
        {
            public string Name { get; set; }
            public Person(string name) { this.Name = name; }
        }
        class Event
        {
            public int EventType { get; set; }
            public Event(int eventType) { this.EventType = eventType; }
        }
        class User
        {
            public string UserName { get; set; }
            public User(string username) { this.UserName = username; }
        }
        public static T GetData<T>(TableType tableType)
        {
            switch (tableType)
            {
                case TableType.Person:
                    Person person = new Person("John");
                    return (T)Convert.ChangeType(person, typeof(T));
                case TableType.Event:
                    Event evt = new Event(2);
                    return (T)Convert.ChangeType(evt, typeof(T));
                case TableType.User:
                    User user = new User("jjesus");
                    return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }
        static void Main(string[] args)
        {
            Person person = GetData<Person>(TableType.Person);
            Console.WriteLine("Person.Name {0}", person.Name);
            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
        }
    }
