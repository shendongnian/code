   		public ActionResult Index()
		{
			return RedirectToAction("Register");
		}
	    public ActionResult Register()
	    {
			return View("Register");   
	    }
		public ActionResult Register(User u)
		{
			if (ModelState.IsValid)
			{
				string s = u.Name;
				return View("Index");
			}
			else
			{
				return View();
			}
		}
