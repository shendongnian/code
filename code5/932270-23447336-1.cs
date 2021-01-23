            public System.Data.Entity.DbSet<GroupToRoles> GroupToRolesTable { get; set; }
            public System.Data.Entity.DbSet<Group> Groups { get; set; }
            public System.Data.Entity.DbSet<ApplicationUser> Users { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelbuilder)
            {
                modelbuilder.Entity<ApplicationUser>().ToTable("Users");
                modelbuilder.Entity<ApplicationUser>().HasKey(u => u.Id);
                modelbuilder.Entity<ApplicationUser>().HasMany(u => u.RolesToGroups);//.WithRequired(/*u => u.User*/).HasForeignKey(u => u.UserId);
    
                modelbuilder.Entity<GroupToRoles>().ToTable("GroupToRolesTable").HasKey(u => u.GroupToRolesId);
    
                modelbuilder.Entity<IdentityUserLogin>().HasKey(u => u.ProviderKey);
                modelbuilder.Entity<IdentityUserRole>().HasKey(u => u.RoleId);
    
                modelbuilder.Entity<Group>().ToTable("Groups");
                modelbuilder.Entity<Group>().HasKey(u => u.GroupId);
                modelbuilder.Entity<Group>().HasMany(u => u.Roles);//.WithRequired(/*u => u.Group*/).HasForeignKey(u => u.GroupId);
            }
