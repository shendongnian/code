    public class D : IEqualityComparer<Account>
    {
        public bool Equals(Account x, Account y)
        {
            return x.ID == y.ID && x.Value==y.Value;
        }
        public int GetHashCode(Account obj)
        {
            return obj.ID.GetHashCode() ^ obj.Value.GetHashCode();
        }
    }
