	//The OutputCacheAttribute in the global filter won't be called
	//Only this OutputCacheAttribute is called since AllowMultiple in OutputCacheAttribute is false
	[[OutputCacheAttribute(Location = OutputCacheLocation.Server, Duration = 100)]
	public ActionResult Index()
	{
		return View();
	}
