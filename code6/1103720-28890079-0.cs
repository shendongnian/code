    public class AccountDomainEqualityComparer : IEqualityComparer<AccountDomain>
    {
        public static readonly AccountDomainEqualityComparer Instance
            = new AccountDomainEqualityComparer();
    
        private AccountDomainEqualityComparer()
        {
        }
    
        public bool Equals(AccountDomain x, AccountDomain y)
        {
            if (ReferenceEquals(x, y))
                return true;
    
            if (x == null || y == null)
                return false;
    
            return x.MAILDOMAIN == y.MAILDOMAIN
                && x.ORG_NAME == y.ORG_NAME;
        }
    
        public int GetHashCode(AccountDomain obj)
        {
            if (obj == null)
                return 0;
            return (obj.MAILDOMAIN ?? string.Empty).GetHashCode()
                ^ (397 * (obj.ORG_NAME ?? string.Empty).GetHashCode());
        }
    }
