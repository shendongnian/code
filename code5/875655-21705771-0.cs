    ClientAccountAccess clientAccess = db.ClientAccountAccesses
        .OrderByDescending(x => x.Id)
        .Take(1)
        .SingleOrDefault();
    
    if (clientAccess != null)
    {
        db.DeleteObject(clientAccess);
    }
