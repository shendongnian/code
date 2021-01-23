        var roleSystem=RpUserRoles.Create(new UserRole() { Name = "System" });
        var rolAdmin=RpUserRoles.Create(new UserRole() { Name = "Admin" });
        //var roleSystem = RpUserRoles.Table.Where(x => x.Name.Equals("System")).FirstOrDefault();
        User userSystem = new User();
        userSystem.Name = "UserSystem";
        userSystem.UserRole = roleSystem;
        RpUser.Create(userSystem);
    
        //var roleAdmin = RpUserRoles.Table.Where(x => x.Name.Equals("Admin")).FirstOrDefault();
        User userAdmin = new User();
        userAdmin.Name = "UserAdmin";
        userAdmin.UserRoleId = roleAdmin.Id;
        RpUser.Create(userAdmin);
