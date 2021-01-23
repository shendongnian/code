    public class Person : IComparable<Person>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int CompareTo(Person obj)
        {
            var val = String.Compare(LastName, obj.LastName, StringComparison.Ordinal);
            // Same LastName case
            if (0 == val)
                val = String.Compare(FirstName, obj.FirstName, StringComparison.Ordinal);
            return val;
        }
    }
            var list = new List<Person>
            {
                 new Person {FirstName = "Viviane", LastName = "York"},
                new Person {FirstName = "Mike", LastName = "Buffalo"},
                new Person {FirstName = "Theo", LastName = "York"},
                new Person {FirstName = "John", LastName = "Case"}
            };
            list.Sort(); // Sort will call IComparable implementation of the Person class
