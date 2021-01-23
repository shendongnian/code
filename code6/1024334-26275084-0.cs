    List<Event> list;
    using (var db = new DbContext())
    {
        db.Configuration.ProxyCreationEnabled = false;
        var dbQuery = db.Set<Event>();
        dbQuery.Include(x => x.Location);
        list = dbQuery.ToList();
    }
