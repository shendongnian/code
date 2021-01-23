    using (var db = new AppContext())
    {
        if (!db.Database.Exists())
        {
            db.Database.Initialize(true);
        }
        
        // query
    }
