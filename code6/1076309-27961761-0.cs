    public struct Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public readonly string FirstName;
        public readonly string LastName;
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
