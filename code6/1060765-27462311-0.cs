    var cmp = new Company{ CmpId = 1, Name = "Cmp1" }; // CmpId is the primary key
    db.Companies.Attach(cmp);
    db.Entry(cmp).Property(c => c.Name).IsModified = true;
    
    try
    {
        db.Configuration.ValidateOnSaveEnabled = false;
        db.SaveChanges();
    }
    finally
    {
        db.Configuration.ValidateOnSaveEnabled = true;
    }
