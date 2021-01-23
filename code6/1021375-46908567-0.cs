        var roleManager = new RoleManager<CustomRole,int>(new RoleStore<CustomRole,int,CustomUserRole>(context));
    	var UserManager = new UserManager<ApplicationUser,int>(new UserStore<ApplicationUser,CustomRole,int,CustomUserLogin,CustomUserRole,CustomUserClaim>(context));
       
       // In Startup iam creating first Admin Role and creating a default Admin User     
    	if (!roleManager.RoleExists("Admin")){
    	//first we create Admin rool   
    		var role = new CustomRole();
    		role.Name = "Admin";
    		roleManager.Create(role);
    	}
    	
        ////Here we create a Admin super user who will maintain the website     
    	if (UserManager.FindByName("Admin") == null){
    		var user = new ApplicationUser() { UserName = "Admin" };
    		string userPWD = "adminadmin";
    		var chkUser = UserManager.Create(user, userPWD);
    		if (chkUser.Succeeded){
    			var result1 = UserManager.AddToRole(user.Id, "Admin")
    			;
    		}
    	}
