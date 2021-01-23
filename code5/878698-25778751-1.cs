    public class PrivateMessageContext : DbContext
    {
        public PrivateMessageContext()
            : base("PrivateMessageContext")
        {
           Database.SetInitializer( new PrivateMessageInitializer<PrivateMessageContext>());
        }
        public DbSet<PrivateMessageHeader> PrivateMessageHeader { get; set; }
        public DbSet<PrivateMessageDetail> PrivateMessageDetail { get; set; }
    
    
    }
