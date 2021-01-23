    public List<User> GetAllUsersByRoleForDashboard(String role)
    {
        List<User> userList = new List<User>();
    
        var userNamesFromDB = new HashSet<string>(Roles.GetUsersInRole(role));
    
    	var users = databaseContext.aspnet_Users.Where(u=>userNamesFromDB.Contains(u.UserName))
    	.Select(u=> new User
    	{
    			// Do your mapping
    	}).ToList();
    
        return users;
    }
