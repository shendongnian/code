		[HttpPost]
		public ActionResult Index(string[] dynamicField)
		{
			ViewBag.Data = string.Join(",", dynamicField ?? new string[] {});
			return View();
		} 
