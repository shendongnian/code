    public class AccountsMap : ClassMap<Accounts>
    {
        public AccountsMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Username).Unique(); // Here the username column will be unique and not null
            Map(x => x.Password);
            
        }
    }
