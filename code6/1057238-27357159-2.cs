    private static void Main()
    {
        using (SqlServerDataContext ctx = new SqlServerDataContext())
        {
            UserRole role = new UserRole();
            role.Name = "Super";
            UserPermission prm1 = new UserPermission();
            prm1.Name = "Delete";
            role.UserPermissions.Add(prm1);
            UserPermission prm2 = new UserPermission();
            prm2.Name = "Add";
            role.UserPermissions.Add(prm2);
            UserPermission prm3 = new UserPermission();
            prm3.Name = "Edit";
            role.UserPermissions.Add(prm3);
            
            ctx.SaveChanges();
            User user = new User();
            user.Name = "User 1";
            user.UserRole = role;
            
            ctx.Users.Add(user);
            
            ctx.SaveChanges();
        }
        using (SqlServerDataContext ctx = new SqlServerDataContext())
        {
            var b = ctx.Users.Find(1);
            // Method 1
            var roleName = b.UserRole.Name;
            // Method 2
            ctx.Users.Include(x => x.UserRole).Include(x => x.UserRole.UserPermissions).FirstOrDefault(x => x.Id == 1);
        }
    }
