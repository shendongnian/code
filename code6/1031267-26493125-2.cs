    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    
        // This comparer will be used to find records that exist or don't exist.
        public class KeyFieldComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person p1, Person p2)
            {
                return p1.FirstName == p2.FirstName && p1.LastName == p2.LastName;
            }
    
            public int GetHashCode(Person p)
            {
                return p.FirstName.GetHashCode() ^ p.LastName.GetHashCode();
            }
        }
    
        // This comparer will be used to find records that are outdated and need to be updated.
        public class OutdatedComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person p1, Person p2)
            {
                return p1.FirstName == p2.FirstName && p1.LastName == p2.LastName && (p1.PhoneNumber != p2.PhoneNumber || p1.Address != p2.Address);
            }
    
            public int GetHashCode(Person p)
            {
                return p.FirstName.GetHashCode() ^ p.LastName.GetHashCode();
            }
        }
    }
