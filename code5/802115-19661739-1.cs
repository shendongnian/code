    public ActionResult Register(UserModel model)
    {
    	User user = Mapper.Map<User>(model);	
    	user.Password = PasswordHelper.GenerateHashedPassword();
    	_db.Users.Add(user);
    	_db.SaveChanges();
    }
