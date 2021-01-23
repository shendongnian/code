    public ActionResult Create(SomeViewModel model)
    {
        if (ModelState.IsValid)
    	{
    		model.Post.Body = model.Body;
    		db.Posts.Add(model.Post);
    		db.SaveChanges();
    		return RedirectToAction("Index");
    	}
    	return RedirectToAction("Index");
    }
