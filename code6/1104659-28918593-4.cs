    sealed class MyComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x == null)
                return y == null;
            else if (y == null)
                return false;
            else
                return x.ID == y.ID && x.Name == y.Name;
        }
    
        public int GetHashCode(Employee obj)
        {
             unchecked
             {
                  int hash = 17;
                  hash = hash * 23 + obj.ID.GetHashCode();
                  hash = hash * 23 + obj.Name.GetHashCode();
                  return hash;
            }
        }
    }
