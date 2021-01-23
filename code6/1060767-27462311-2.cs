    var cmp = new Company{ CmpId = 1, Name = "Cmp1" }; // CmpId is the primary key
    db.Companies.Attach(cmp);
    db.Entry(cmp).Property(c => c.Name).IsModified = true;
    // Or add an entity to a collection:
    cmp.Users = new[] {new User { Name = "a1", PassWord = "a1" } };
    
    try
    {
        db.Configuration.ValidateOnSaveEnabled = false;
        db.SaveChanges();
    }
    finally
    {
        db.Configuration.ValidateOnSaveEnabled = true;
    }
