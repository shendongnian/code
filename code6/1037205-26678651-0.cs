    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    
        // This comparer will be used to find records that exist or don't exist.
        public class KeyFieldComparer : IEqualityComparer<User>
        {
            public bool Equals(User u1, User u2)
            {
                return u1.Name == u2.Name && u1.Surname == u2.Surname;
            }
    
            public int GetHashCode(User u)
            {
                return u.Name.GetHashCode() ^ u.Surname.GetHashCode();
            }
        }
    }
