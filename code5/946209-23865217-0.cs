	[HttpPost]
	[SiteMapCacheRelease]
	public ActionResult Edit(int id, Product product)
	{
		try
		{
			using (var db = new CRUDExample())
			{
				var model = (from p in db.Product
						 where p.Id == id
						 select p).FirstOrDefault();
				if (model != null)
				{
					model.Name = product.Name;
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
