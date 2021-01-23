	[HttpPost]
	public ActionResult UpdateItems(Test model)
		{
			if (model != null)
			{
				// You can access model.Items here
				//Do whatever you need
			}
		return View(model);
	}
