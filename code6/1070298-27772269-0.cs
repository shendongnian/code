    //Materializing a collection of users
    public ActionResult Users() 
    {
        //The DbContext has been initialized elsewhere
        var users = _db.User.Where(user => user.IsActive).ToList();
        return View(users);
    }
    //Materializing a single record
    public ActionResult User(int userId)
    {
        var user = _db.User.FirstOrDefault(user => user.Id == userId);
        if (user == null) return HttpNotFound();
        return View(user);
    }
