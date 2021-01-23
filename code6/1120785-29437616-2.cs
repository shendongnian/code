    public List<User> GetAllUsersByRoleForDashboard(String role)
    {
        var userNamesFromDB = new HashSet<string>(Roles.GetUsersInRole(role));
    
    	var users = context.aspnet_Users.Where(u => userNamesFromDB.Contains(u.UserName))
    	.Select(u=> new User
    	{
    		// Do your mapping
    	}).ToList();
    
        return users;
    }
