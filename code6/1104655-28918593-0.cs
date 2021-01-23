    sealed class MyComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x == null)
                return y == null;
            else if (y == null)
                return false;
            else
                return x.ID == y.ID && x.Name == y.Name ;
        }
    
        public int GetHashCode(Employee obj)
        {
            return obj.ID.GetHashCode();
        }
    }
