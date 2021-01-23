    try
    {
        db.User.FirstName = user.FirstName;
        db.User.LastName = user.LastName;
        db.Entry(db.User).State = EntityState.Modified;
        db.SaveChanges();
    }
    
