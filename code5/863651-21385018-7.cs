    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (object.ReferenceEquals(x, y)) return true;
            if (x == null ||y == null) return false;
            return x.UserId == y.UserId && x.FullName == y.FullName;
        }
        public int GetHashCode(User obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (obj.UserId ?? "").GetHashCode();
                hash = hash * 23 + (obj.FullName ?? "").GetHashCode();
                return hash;
            }
        }
    }
