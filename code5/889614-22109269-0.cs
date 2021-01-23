    public class Person : IComparable<Person>
    {
        public string Age { get; set; }
        public int CompareTo(Person other)
        {
            return int.Parse(other.Age).CompareTo(int.Parse(this.Age));
        }
    }
