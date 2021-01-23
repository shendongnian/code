    if (ModelState.IsValid)
    {
    	if (User != null && User.Identity != null && User.Identity.IsAuthenicated)
    	{
    		string userName = User.Identity.Name;
    		User user = db.Users.First(u => u.UserName == userName);
    		
    		icerik.UserId = user.UserId;		
    		db.icerik.Add(icerik);
    		db.SaveChanges();
    		return RedirectToAction("Index");  
    	}
    }
