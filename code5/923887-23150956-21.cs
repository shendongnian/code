	[SiteMapTitle("Name")]
	public ActionResult Details(int id)
	{
		using (var db = new EntityContext())
		{
			var model = (from staff in db.Staff
						where staff.Id == id
						select staff).FirstOrDefault();
			return View(model);
		}
	}
