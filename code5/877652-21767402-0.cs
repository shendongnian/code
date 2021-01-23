    public class Account
    {
       public int Id { get; set; }
       public ICollection<User> Users { get; set; }
    }
    public class User
    {
       public int Id { get; set; }
       public Account Account { get; set; }
    }
    public class AccountContext : DbContext
    {
       public AccountContext()
            : base("DefaultConnection")
        {
        }
       public DbSet<Account> Accounts;
       public DbSet<User> Users;
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasRequired(u => u.Account) 
                .WithMany(a => a.Users) 
                .HasForeignKey(u => u.AccountId);
        }
    }
