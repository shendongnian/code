    public class PrivateMessageContext : DbContext
    {
        public DbSet<PrivateMessageHeader> PrivateMessages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<PrivateMessageContext>(null);
        }
    }
