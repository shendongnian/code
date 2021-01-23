	private readonly object _countLock = new object();
	public ActionResult Index()
    {
    	lock(_countLock)
    	{
	        ViewBag.BeforeCount = StaticVariableTester.Count;
	        StaticVariableTester.Count += 50;
        }
        return View();
    }   
