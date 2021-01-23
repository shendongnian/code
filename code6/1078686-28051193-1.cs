    public class YourContext : DbContext
    {
        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOptional(c => c.Account)
                .WithMany(e => e.Contacts)
                .HasForeignKey(a => a.AccountId);
            modelBuilder.Entity<Account>()
             .HasOptional(c => c.PrincipalContact)
             .WithMany()
             .Map(c => c.MapKey("PrincipalContactId"));
       }
    }
