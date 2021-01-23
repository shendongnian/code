    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateUser(CreateUserViewModel createUserViewModel)
    {
    	if (ModelState.IsValid)
        {
    		CreateSystemUserCommand createSystemUserCommand = new CreateSystemUserCommand()
    		{
    			Firstname = createUserViewModel.Forename,
    			Surname = createUserViewModel.Surname,
    			Username = createUserViewModel.Username,
    			Password = createUserViewModel.Password
    		};
    
    		CreateSystemUserCommandHandler handler = new CreateSystemUserCommandHandler();
    
    		handler.Execute(createSystemUserCommand);
    
    		return RedirectToAction("ViewUsers");
    	}
    	
    	return View(createUserViewModel);
    }
