    using(var db = new MyDbContext())
    {
        var items = db.MyItems.Where(i => i.Something == true);
    	var list = items.ToList(); // <= here the DB is queried
    }
