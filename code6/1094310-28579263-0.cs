    namespace Intersects
    {
        class Person
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var persons = new[]
                    {
                        new Person() {Name = "Jack", BirthDate = new DateTime(1990, 1, 1)},
                        new Person() {Name = "Joe", BirthDate = new DateTime(1970, 9, 9)},
                        new Person() {Name = "Ivan", BirthDate = new DateTime(1991, 2, 2)},
                    };
    
                var birthDates = new[]
                    {
                        new DateTime(1990, 1, 1),
                        new DateTime(1991, 2, 2),
                        new DateTime(1991, 3, 3),
                    };
    
                var joined = from p in persons
                             join bd in birthDates
                             on p.BirthDate.Year equals bd.Year // Your own custom logic
                             select p;
    
                foreach (var person in joined)
                {
                    Console.WriteLine(person.Name);
                }
    
                // Output:
                //Jack
                //Ivan
                //Ivan
            }
        }
    }
