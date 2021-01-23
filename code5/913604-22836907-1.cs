	public static class StaticVariableTester
	{
		private static int _count;
		public static int Count
		{
			get { return _count; }
		}
		public static int IncrementCount(int value)
		{
			//increments and returns the old value of _count
			return Interlocked.Add(ref _count, value);
		}
	}
	public ActionResult Index()
    {
    	ViewBag.BeforeCount = StaticVariableTester.IncrementCount(50);
        return View();
    } 
