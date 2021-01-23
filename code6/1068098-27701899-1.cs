    [HttpPost]
	public ActionResult Login(string user_name,string password)
	{
		if (ModelState.IsValid)
		{
			var x = (from n in db.Customers
					 where n.User_Name==user_name && n.Password==password                         
					 select n).FirstOrDefault();
			if (x != null)
			{
				Session["UserName"] = x.First_Name;    
				//Authenticating the user  
				FormsAuthentication.SetAuthCookie(x.First_Name, false);
				return RedirectToAction("Products","Home");
			}
			else
			{
				@ViewBag.ErrorValidationFailed = "Invalid username or password";                    
				return View();
			}
		}
		return View();
	}
