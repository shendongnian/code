    class BusinessComparer : IEqualityComparer<Business>
    {
        public bool Equals(Business x, Business y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Name == y.Name;
        }
    
        public int GetHashCode(Business business)
        {
            if (Object.ReferenceEquals(business, null))
                return 0;
            int hashBusinessName = business.Name == null ? 0 : business.Name.GetHashCode();
            return hashProductName;
        }
    }
