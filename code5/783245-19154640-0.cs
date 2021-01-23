    public class Person
    {
        public string FirstName {get; set; }
        public string LastName {get; set; }
    
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
    
    public static class People
    {
        public static Person Jack= new Person("Jack", "Andersson");
    }
