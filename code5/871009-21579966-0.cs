    public class Person
    {
        public List<Person> Friends { get; private set; }
    
        public Person() 
        {
           this.Friends = new List<Person>();
        }
    }
