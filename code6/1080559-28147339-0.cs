    namespace Core
    {
        public partial class BaseContext : DbContext
        {
            public BaseContext()
            {
            }
            public BaseContext(string connectionString)
                : base(connectionString)
            {
            }
            public DbSet<SystemUser> SystemUser { get; set; }
        }
        public partial class SystemUser
        {
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
        }
    }
