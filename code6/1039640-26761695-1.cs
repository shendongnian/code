    public class Person : IComparable<Person>
        {
            public int Age { get; set; }
    
            public int CompareTo(Person other)
            {
                return this.Age.CompareTo(other.Age);
            }
        }
