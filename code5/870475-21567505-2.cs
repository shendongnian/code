	//The NoCacheAttribute in the global filter won't be called
	//Only this NoCacheAttribute is called since AllowMultiple is false
	[NoCacheAttribute(Disable =  true)]
	public ActionResult Index()
	{
		return View();
	}
