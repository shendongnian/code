    public class AccountsMap : ClassMap<Accounts>
    {
        public AccountsMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Username).Unique().Nullable(); // Here the username column will be unique 
            Map(x => x.Password);
            
        }
    }
