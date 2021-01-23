    class CountryCodeComparer : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            if(object.ReferenceEquals(x, y)) return true;
            if(x == null || y == null) return false;
            return x.CountryCode == y.CountryCode;
        }
        public int GetHashCode(Country obj)
        {
            return obj == null ? 0 : obj.CountryCode == null ? 0 : obj.CountryCode.GetHashCode();
        }
    }
