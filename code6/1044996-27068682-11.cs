	public async System.Threading.Tasks.Task<bool> CreateUserAsync(string fbid)
	{
		using (var context = new ApplicationDbContext())
		{
			var newUser = new ApplicationUser() { UserName = fbid, Email = "xxx@gmail.com" }; 
			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
			try
			{
				var result = await userManager.CreateAsync(newUser, "Admin@123456");
				var test   = await context.SaveChangesAsync();                    
				return result.Succeeded;                   
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
