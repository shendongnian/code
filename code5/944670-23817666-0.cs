	protected override void Seed(MyFirstWebApplication.Models.ApplicationDbContext context)
	{
		if( !context.Users.Any( u => u.Email == "test@mail.com" ) )
		{
			var userStore = new UserStore<ApplicationUser>(context);
			var manager = new UserManager<ApplicationUser>(userStore);
			var user = new ApplicationUser() { UserName = "test@mail.com", Email = "test@mail.com", Name = "Martin Tracey" };
			IdentityResult result = manager.Create(user, "password");}
		}
	}
