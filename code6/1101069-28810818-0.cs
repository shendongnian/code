    SidewindContext db = new SidewindContext();
    db.Attach(user);
    if (user.ChangedPassword == false)
    {
        user.ChangedPassword = true;
    }
    db.SaveChanges();
