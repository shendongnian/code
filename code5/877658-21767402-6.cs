    public class Account
    {
       public int Id { get; set; } //as Id in Accounts Table
       public ICollection<User> Users { get; set; }
    }
    public class User
    {
       public int Id { get; set; } //as Id in Users Table
 
       public Account Account { get; set; } // as Account_Id in Users Table
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
     
