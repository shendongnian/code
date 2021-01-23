    // Query entity A
    var AList = App.DB.Table<EntityA>().ToList();
    if (AList == null || AList.Count == 0)
        return;
    // Get entity B for each item
    foreach (EntityA ea in AList)
    {
        // I'm retreiving just a single element here.. of course you can easily pull a list here for one to many relationships..
        var eb = App.DB.Table<EntityB>().Where(b => b.EntityAIndex == ea.DBId).FirstOrDefault();
        if (eb == null)
            continue;
        ea.EntityB = eb;
    }
