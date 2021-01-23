    public class AccountMap
    {
        public AccountMap()
        {
            Id(x=>x.Id.Id).GeneratedBy.GuidComb();
            References(x => x.Tenant);  // Foreign Key.
            Map(x => x.AccountName).Not.Nullable();
        }
    }
