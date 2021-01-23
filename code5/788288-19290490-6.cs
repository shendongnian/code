    [HttpPost]
    public ActionResult Register(RegisterModel registerModel)
    {
    	// Map RegisterModel to a User model.    	
    	var user = new User
    				   {
    						UserName = registerModel.UserName,
    						Password = registerModel.Password	// Do the hasing here for example.
    					};
    	db.Users.Add(user);
    	db.SaveChanges();							
    }
