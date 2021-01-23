	[AcceptVerbs(HttpVerbs.Post)]
	public ActionResult Index(Repair r)
	{
		ModelState.Clear(); //Added here
		r.Number = "New Value";
		return View(r);
	}
