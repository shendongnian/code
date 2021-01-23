    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    var result = await UserManager.CreateAsync(user, model.Password);
    if (result.Succeeded)
    {
      var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
      var roleManager = new RoleManager<IdentityRole>(roleStore);
      if(!await roleManager.RoleExistsAsync("YourRoleName"))
         await roleManager.CreateAsync(new IdentityRole("YourRoleName"));
      await UserManager.AddToRoleAsync(user.Id, "YourRoleName");
      await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
      return RedirectToAction("Index", "Home");
    }
