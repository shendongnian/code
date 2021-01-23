	[Authorize(Roles = "Admin")]
	public ActionResult AdminUserManagement()
	{
		IEnumerable<ManagerUserViewModel>() viewModels;
        using(var context = new IdentityDbContext()){
			viewModels =
				context.Users
				.Include("Roles")
				.Select(u =>
					new ManagerUserViewModel { 
						UserID = u.Id, 
						UserName =  u.UserName, 
						Role = u.Roles.First().Role.ToString() 
					}
				).ToList();
		}
        return View(viewModels);
    }
	
