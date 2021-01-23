	[HttpPost]
	public ActionResult Index()
	{
		ViewBag.IsCheckedIn = true;
		return View();
	}
	
