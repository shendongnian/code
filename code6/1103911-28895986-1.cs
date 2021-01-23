    [HttpPost]
    public ActionResult RegisterNewUser(RegisterModel model)
    {
    	ViewBag.Message = "Register";
    	string msg = "";
    
    	if (!users.RegisterUser(model.uName, model.email, model.password))
    	{
    	    msg = "The provided email already exists";
    	}
    
    	ViewBag.Message = msg;
    	return PartialView("_Register");            
    }
