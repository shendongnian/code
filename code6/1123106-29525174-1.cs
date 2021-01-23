    public class AccountComparer : IEqualityComparer<IAccount>
    {
        public bool Equals(IAccount x, IAccount y)
        {
            return x.AccountCode == y.AccountCode &&
                x.AccountDate == y.AccountDate &&
                x.SalesCode == y.SalesCode;
        }
        public int GetHashCode(IAccount obj)
        {
            return (obj.AccountCode + obj.AccountDate + obj.SalesCode).GetHashCode();
        }
    }
