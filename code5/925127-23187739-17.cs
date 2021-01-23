    public class State {
        // If you need more than 256 State entities, just bump it to a short
        // and you should be good to for every possible State (or Province) in the world
        public byte Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
    public class Country {
        public byte Id { get; set; }
        public string Abberviation { get; set; }
        public string Name { get; set; }
    }
    public class Address {
        // Blah, blah, blah...
        // Nullable because not all countries have states
        public byte? StateId { get; set; }
        public byte CountryId { get; set; }
        public virtual State { get; set; }
        public virtual Country { get; set; }
    }
