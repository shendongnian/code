    public ActionResult Edit(int id)
    {
    	// Get the currently logged in user.
    	string userName = User.Identity.Name;
    	var user = db.Users.First(u => u.UserName == userName);
    	
    	// Determine whether the requested id is the same id as the currently logged in user.
    	if (id == user.UserId)
    	{		
    		icerik icerik = db.icerik.Find(id);
    		ViewBag.Kategorid = new SelectList(db.Kategoriler, "Id", "Adi", icerik.Kategorid);
    		
    		// You should not need this SelectList anymore.
    		//ViewBag.Userid = new SelectList(db.Users, "UserId", "UserName", icerik.Userid);
    		return View(icerik);
    	}
    }
