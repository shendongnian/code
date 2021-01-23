    public class MyContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
    }
