    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class Helper
    {
        public static IList<Person> GetPersons()
        {
            return new List<Person>()
            {
                new Person(){FirstName = "Kanye", LastName ="West", Age = 33},
                new Person(){FirstName = "Justin", LastName ="Timberlake", Age = 18},
                new Person(){FirstName = "Celine", LastName ="Dion", Age = 38},
                new Person(){FirstName = "Samantha", LastName ="Jade", Age = 33},
                new Person(){FirstName = "Marshal", LastName ="Matters", Age = 35},
                new Person(){FirstName = "Armando", LastName ="Perez", Age = 14}
            };
        }
    }
