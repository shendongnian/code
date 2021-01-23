    class Person : IEquatable<Person> {
        // these should be properties, e.g. public string Name { get; set; }
        string Name;
        string SSN;
        public override int GetHashCode() {
            // XOR is not the best generally, but can work for something like this
            return Name.GetHashCode() ^ SSN.GetHashCode();
        }
        public override bool Equals(object other) {
            return Equals(other as Person);
        }
        public bool Equals(Person other) {
            return other != null && this.Name == other.Name && this.SSN == other.SSN;
        }
    }
    var newPerson = person.Distinct().ToList();
