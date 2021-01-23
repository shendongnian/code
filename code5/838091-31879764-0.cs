        public virtual MyUserInfo MyUserInfo { get; set; } 
    } 
  
    public class MyUserInfo{ 
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
    } 
    public class MyDbContext : IdentityDbContext<MyUser> 
    { 
        public MyDbContext() 
            : base("DefaultConnection") 
        { 
        } 
        public System.Data.Entity.DbSet<MyUserInfo> MyUserInfo { get; set; } 
     } 
