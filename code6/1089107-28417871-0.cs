    public ActionResult Create(User user)
    {
        var res = (from c in db.Users
                   where c.Email == user.Email
                   select c).SingleOrDefault();
        if(res == null)
        {
            db.Users.Add(user);
        }
        else
        {
            res.Prop1 = user.Prop1
            res.Prop2 = user.Prop2
            ...
        }
        db.SaveChanges();
        return RedirectToAction("Index");
    }
