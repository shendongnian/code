    public class UsersDbContext: DbContext
    {
        public UsersDbContext(): base("name=ConnectionStringName") { }
        ...
    }
    public class CategoriesDbContext: DbContext
    {
        public CategoriesDbContext(): base("name=ConnectionStringName") { }
        ...
    }
