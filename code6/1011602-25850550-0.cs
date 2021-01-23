    public class NameAndBirthdayComparer : IEqualityComparer<userObj>
    {
        public bool Equals(userObj x, userObj y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName && x.BirthDate == y.BirthDate;
        }
        public int GetHashCode(userObj obj)
        {
            unchecked
            {
                var hash = (int)2166136261;
                hash = hash * 16777619 ^ obj.FirstName.GetHashCode();
                hash = hash * 16777619 ^ obj.LastName.GetHashCode();
                hash = hash * 16777619 ^ obj.BirthDate.GetHashCode();
                return hash;
            }
        }
    }
