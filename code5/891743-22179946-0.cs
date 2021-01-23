    if(User.IsInRole("Admin"))
    {
        return View(db.Customers.ToList());
    }
    else
    {
        return View(db.MyUserInfo.ToList());
    }
