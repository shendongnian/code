    // It's easier to implement equality correctly on sealed classes
    public sealed class Person
    {
        private readonly string personName;
    
        public Person(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            this.personName = name;
        }
        public override bool Equals(object other)
        {
            Person person = other as Person;
            return person != null && person.personName.Equals(personName);
        }
        // Must override GetHashCode at the same time...
        public override int GetHashCode()
        {
            // Just delegate to the name here - it's the only thing we're
            // using in the equality check
            return personName.GetHashCode();
        }
    }
