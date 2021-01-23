    //Materializing a collection of users
    public ActionResult Users() 
    {
        //The DbContext has been initialized elsewhere
        var users = _db.Users.Where(user => user.IsActive).ToList();
        return View(users);
    }
    //Materializing a single record
    public ActionResult User(int userId)
    {
        var user = _db.Users.FirstOrDefault(user => user.Id == userId && user.IsActive);
        if (user == null) return HttpNotFound();
        return View(user);
    }
