    public class Account
    {
       [Key]
       public int Id { get; set; }
       public ICollection<User> Users { get; set; }
    }
    public class User
    {
       [Key]
       public int Id { get; set; }
 
       [ForeignKey("Account"), DatabaseGenerated(DatabaseGeneratedOption.None)]
       public int AccountId { get; set; }
       public Account Account { get; set; }
    }
    // and of course you need your context class, but with less code
    public class AccountContext : DbContext
    {
       public AccountContext()
            : base("DefaultConnection")
        {
        }
       public DbSet<Account> Accounts { get; set; }
       public DbSet<User> Users { get; set; }       
    }
