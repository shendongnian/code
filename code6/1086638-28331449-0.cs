    public class MyContext: IdentityDbContext<ApplicationUser>
        {
            public MyContext() : base("MyContext")
            {   
            }
            public static MyContextCreate()
            {
                return new MyContext();
            }
            public System.Data.Entity.DbSet<xxx> xxx{ get; set; }
        }
