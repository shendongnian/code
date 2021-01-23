    // previous code
    db.Connection.Open();
    using (var transaction = db.Connection.BeginTransaction())
    {
        // do stuff inside transaction
    }
    // changed to the following WRONG code
    db.Database.Connection.Open();
    using (var transaction = db.Database.Connection.BeginTransaction())
    {
        // do stuff inside transaction
    }
