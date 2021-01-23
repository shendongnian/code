    public class Repository
    {
        Model1 db = new Model1(); // Entity Framework context
        // User Roles
        public IList<DbUserRoles> GetAllUserRoles()
        {
            return db.DbUserRoles.OrderBy(e => e.UserRoleId).ToList();
        }
    }
