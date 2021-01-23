    public class PrivateMessageContext : DbContext
    {
        public PrivateMessageContext()
            : base("PrivateMessageContext")
        {
           Database.SetInitializer(
      new MigrateDatabaseToLatestVersion<PrivateMessageContext,
        DatabaseDesign.DAL.PrivateMessageInitializer>());
        }
        public DbSet<PrivateMessageHeader> PrivateMessageHeader { get; set; }
        public DbSet<PrivateMessageDetail> PrivateMessageDetail { get; set; }
    
    
    }
