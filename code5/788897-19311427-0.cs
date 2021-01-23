    public class Account
        : Entity<AccountId>
    {
        public Account(Tenant tenant,AccountId accountId)
        {
            Tenant = tenant;
            Id= accountId;
        }
        public Tenant Tenant {get;set;}
        public string AccountName {get;set;}
    }
