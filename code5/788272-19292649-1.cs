    if (User != null && User.Identity != null && User.Identity.IsAuthenicated)
    {
    	string userName = User.Identity.Name;
    	User user = db.Users.First(u => u.UserName == userName);
    }
