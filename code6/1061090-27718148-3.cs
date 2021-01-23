	public async Task<ActionResult> Create(RegisterViewModel model)
	{
		if (ModelState.IsValid)
		{
			var user = new ApplicationUser() { UserName = model.Username, Email = string.Empty };
			int selected = int.Parse(model.SelectedInstitution);
			
            var context = HttpContext.GetOwinContext().Get<ApplicationDbContext>()
            
         	//Set the id
     	    user.InstitutionId = context.Institutions.Where(x => x.Id == selected).First().Id; 
			
            
			IdentityResult result = await UserManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentitiesDb()));
				UserManager.AddToRole(user.Id.ToString(), roleManager.Roles.Where(x => x.Id == model.SelectedRole.ToString()).First().Name);
				return RedirectToAction("Index", "Users");
			}
			else
			{
				AddErrors(result);
			}
		}
		model.Roles = GetRoles();
		model.Institutions = GetInstitutions();
		return View(model);
	}
	
