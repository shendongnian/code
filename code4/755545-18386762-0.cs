    class Person : IComparable<Person>
    {
        public int age { get; set; }
        public String name { get; set; }
    
        public int CompareTo(Person other)
        {
            if (age > other.age)
    
            { return 1; }
            if (age == other.age)
            { return 0; }
            return -1;
        }
    }
