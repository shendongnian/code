    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
    	if (ModelState.IsValid)
    	{
    		// Authenticate the user with information in LoginModel.
    	}
    	
    	// Something went wrong, redisplay view with the model.
    	return View(model);
    }
