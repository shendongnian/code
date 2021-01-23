	public static void InitializeIdentityForEF(ApplicationDbContext db)
	{
		//ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
		RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
		const string name = "admin@example.com";
		const string password = "Admin@123456";
		const string roleName = "Admin";
		IdentityRole adminRole = new IdentityRole(roleName);
	   
		//Create Role Admin if it does not exist
		if (!roleManager.RoleExists(roleName))
		{
			roleManager.Create(adminRole);
			PasswordHasher hasher = new PasswordHasher();
			ApplicationUser adminUser = new ApplicationUser { UserName = name, Email = name, PasswordHash = hasher.HashPassword(password), LockoutEnabled = false };
			db.Users.Add(adminUser);
			IdentityUserRole userRole = new IdentityUserRole() { RoleId  = adminRole.Id, UserId = adminUser.Id };
			adminUser.Roles.Add(userRole);
			var x = db.SaveChanges();
		}
	}
