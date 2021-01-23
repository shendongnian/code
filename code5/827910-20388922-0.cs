       class PersonEqualityComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person lhs, Person rhs)
            {
                return lhs.Name == rhs.Name;
            }
            public int GetHashCode(Person p)
            {
                return p.Name.GetHashCode();
            }
        }
