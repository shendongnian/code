		protected override void Seed(Holos.Service.Models.ApplicationDbContext context)
		{
			var email		= "xxxx@xxxx.com";
			var password	= "xxxxx";
			var userStore	= new UserStore<ApplicationUser>(context);
			var userManager = new ApplicationUserManager(userStore);
			var user = userManager.FindByEmailAsync(email).Result;
			if (user == null)
			{
				var adminUser = new ApplicationUser() { Email = email, UserName = email };
				var result = userManager.CreateAsync(adminUser, password);
				result.Wait();
				userManager.AddClaimAsync(adminUser.Id, new Claim("Read", "*")).Wait();
				userManager.AddClaimAsync(adminUser.Id, new Claim("Create", "*")).Wait();
				userManager.AddClaimAsync(adminUser.Id, new Claim("Update", "*")).Wait();
				userManager.AddClaimAsync(adminUser.Id, new Claim("Delete", "*")).Wait();
				userManager.AddClaimAsync(adminUser.Id, new Claim("UserType", "SuperUser")).Wait();
			}
		}
