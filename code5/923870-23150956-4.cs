	[SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
	public ActionResult Edit(int id)
	{
		using (var db = new EntityContext())
		{
			var model = (from staff in db.Staff
						 where staff.Id == id
						 select staff).FirstOrDefault();
			return View(model);
		}
	}
	[HttpPost]
	[SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
	public ActionResult Edit(int id, Staff staff)
	{
		try
		{
			using (var db = new EntityContext())
			{
				var model = (from s in db.Staff
							 where s.Id == id
							 select s).FirstOrDefault();
				if (model != null)
				{
					model.Name = staff.Name;
					db.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}
		catch
		{
			return View();
		}
	}
