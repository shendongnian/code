    public class Person : IComparable<Person> 
    {
        public int Age { get; set; }
        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }
    }
