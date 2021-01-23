    public ActionResult Edit(int userId)
    {
    	var model = new UserModel();
    	// get data from db.
    	
    	// Populate countries list.
    	model.Countries = db.Countries.Select(c => new SelectListItem
    												   {
    														Value = c.Id,
    														Text = c.Name
    												   }).ToList();
    }
