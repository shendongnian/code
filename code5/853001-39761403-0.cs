    var role = await this.roleManager.FindByNameAsync( "Admin" );
    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    var userRole = new IdentityUserRole<int> {
                RoleId = role.Id,
            };
    user.Roles.Add(userRole );
    var result = await this.userManager.CreateAsync( user, model.Password); 
