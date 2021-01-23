	public ActionResult ViewUser()
	{
		var model = new UserModel { Username = "a", Password = "p" };
		return View(model);
	} 
