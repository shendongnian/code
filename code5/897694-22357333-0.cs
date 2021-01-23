    foreach(A in ACache.Values)
    {
        process(db, A);
    }
    public void process(Database db, I i)
    {
        int ID = i.ID;
        // retrieve IDatabaseDoingStuffTo
        var iddsti = retrieveDatabaseBridge(i);
        iddsti.DoStuff(db, i);
        int newID = i.ID;
        Bar(i);
    }
