    public ActionResult Index()
    {
    	// Get method.
    	UserSample model = new UserSample();
    	return View(model);
    }
    [HttpPost]
    public ActionResult Index(UserSample user)
    {
    	//  POST method.
    }
