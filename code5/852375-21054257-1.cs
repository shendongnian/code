    public class MySqlContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<LoginModel> LoginModel { get; set; }
        public System.Data.Entity.DbSet<Roles> Roles { get; set; }
        public MySqlContext()
        : base("ConnectionStringName")
        { }
    }
