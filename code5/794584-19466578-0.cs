    //get all or needed users
    List<User> users = dbContext.Users.ToList();
    foreach (var user in users)
    {
    	if (CheckCondition) //update user
    	{
    		user.Name = "new name";
    		dbContext.Entry(user).State = EntityState.Modified;
    	}
    	else if (CheckCondition) // delete user
    	{
    		dbContext.Entry(user).State = EntityState.Deleted;
    	}
    }
    dbContext.Users.Add(new User() {Name = "Name3"}); //add new user
    dbContext.SaveChanges(); //save all changes in one batch in a single transaction
