    public class QueuedEmailMap : ClassMap<QueuedEmail>
    {
        public QueuedEmailMap()
        {
            ...
            // this property will be WRITABLE
            Map(x => x.x.EmailAccountId)
              .Column("EmailAccountId")
            // this one will be readonly
            References(x => x.EmailAccount)
              .Column("EmailAccountId")
              .Not.Nullable()
              .Cascade.All()
              .Not.Insert() // this is the setting
              .Not.Update()
              ;
        ...
