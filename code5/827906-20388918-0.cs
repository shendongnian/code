    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return Equals(x.Name, y.Name);
        }
        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }
    }
