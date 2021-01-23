	public ActionResult Index(int id)
	{
		var model1 = new Model1();
		var model2 = new Model2();
		if (id == 1)
		{
			return View("ViewForModel1", model1);
		}
		
		if (id == 2)
		{
			return View("ViewForModel2", model2);
		}
		
		// if it gets this far, return index
		return View();
	}
