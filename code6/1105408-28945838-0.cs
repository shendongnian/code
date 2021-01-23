    [HttpPost]
    public ActionResult Create(userViewModel model)
    {           
       
    	TryUpdateModel(model);
    	if (ModelState.IsValid) //<= The value of MENU not getting updated
    	{               
    	    model.User.MENU = string.Join(",", model.MenuIds);
    	    _db.Entry(model.User).State = EntityState.Modified;
    	    _db.SaveChanges();
    	}
    	return RedirectToAction("Create");
    }
