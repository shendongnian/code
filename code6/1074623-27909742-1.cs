    using (var context = new YourContext())
    {
    	var access = context.Access.Include(a => a.PermissionList)
                                   .Single(a => a.ID == 42);	
    }
