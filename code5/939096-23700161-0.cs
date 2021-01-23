    public class EmailAccountMap : ClassMap<EmailAccount>
    {
        public EmailAccountMap()
        {
            // your code
            HasMany<QueuedEmail>(x => x.QueueEmail)
               .KeyColumn("EmailAccountId")
               .Inverse()
               .Cascade.All(); 
        }
    }
    public class QueuedEmailMap : ClassMap<QueuedEmail>
    {
        public QueuedEmailMap()
        {
            // your code
            References(x => x.EmailAccount)
              .Column("EmailAccountId")
              .Not.Nullable();
        }
    }
